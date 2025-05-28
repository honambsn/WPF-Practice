using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;

namespace ChessAI
{
	public class Evaluator
	{
		private GameState currentState;

		public int EvaluateBoard(GameState state)
		{
			currentState = state;

			int materialScore = 0;
			int centerControlScore = 0;
			int kingSafetyScore = 0;
			int developmentScore = 0;
			int threatPenaltyScore = 0;
			int defensePenaltyScore = 0;
			int defenseBonusScore = 0;
			int mobilityScore = 0;
            int pawnStructureScore = 0;

            var whiteMoves = MoveGenerator.GenerateForPlayer(state, Player.White).ToList();
			var blackMoves = MoveGenerator.GenerateForPlayer(state, Player.Black).ToList();


			foreach (var player in new[] { Player.White, Player.Black })
			{
				var positions = state.Board.PiecePositionsFor(player);
				var enemyMoves = (player == Player.White) ? blackMoves : whiteMoves;
				var friendlyMoves = (player == Player.White) ? whiteMoves : blackMoves;

				foreach (var pos in positions)
				{
					var piece = state.Board[pos];
					int sign = (piece.Color == state.CurrentPlayer.Opponent()) ? 1 : -1;

					materialScore += sign * GetPieceValue(piece.Type);
					materialScore += sign * GetPositionValue(piece.Type, piece.Color, pos);

					centerControlScore += sign * EvaluateCenterControl(piece.Type, pos);
					kingSafetyScore += sign * EvaluateKingSafety(piece.Type, piece.Color, pos);
					developmentScore += sign * EvaluateDevelopment(piece.Type, piece.Color, pos);
					threatPenaltyScore -= sign * GetThreatPenalty(state, pos, piece.Color, enemyMoves, friendlyMoves);
					defenseBonusScore += sign * GetDenfenseBonus(pos, piece.Color, friendlyMoves, state);

                    if (IsWeaklyDefended(pos, piece.Color, enemyMoves, friendlyMoves))
					{
						defensePenaltyScore -= sign * 30; // có thể tùy chỉnh mức phạt
					}

                    if (IsThreatened(state, pos, piece.Color))
                    {
                        defensePenaltyScore -= sign * 20; // có thể tùy chỉnh mức phạt
                    }
                }
			}
			mobilityScore += (whiteMoves.Count() - blackMoves.Count()) * 2;

            pawnStructureScore += EvaluatePawnStructure(state, Player.White);
            pawnStructureScore -= EvaluatePawnStructure(state, Player.Black);

			double phase = GetGamePhase(state);
			int midEvaluation = (int)(materialScore + centerControlScore + kingSafetyScore + developmentScore +
				threatPenaltyScore * 2 + defensePenaltyScore + defenseBonusScore + mobilityScore + pawnStructureScore);

			int endEvaluation = (int)EvaluateEndGameFeatures(state);

    //        return materialScore + centerControlScore + kingSafetyScore + developmentScore + 
				//threatPenaltyScore * 2 + defensePenaltyScore + defenseBonusScore;
				return (int)((1 - phase) * midEvaluation + phase * endEvaluation);
        }

        private int EvaluateEndGameFeatures(GameState state)
        {
			int score = 0;

			foreach (var player in new[] { Player.White, Player.Black })
			{
				var kingPos = FindKingPosition(state, player);
				var opponent = player.Opponent();

                // centralize king in endgame
				int disToCenter = Math.Abs(kingPos.Row - 3) + Math.Abs(kingPos.Column - 3);
				int sign = (player == state.CurrentPlayer) ? 1 : -1;
				score -= sign * disToCenter * 5; // modify this value to adjust the importance of king centralization

                // penalize king safety in endgame
				var surroundingSquare = GetSurroundingPositions(kingPos);
                int safeSquares = surroundingSquare.Count(p =>
                state.Board.isInside(p) && (!state.Board.HasPieceAt(p) || state.Board[p].Color == player));

				score += sign * safeSquares * 10; // modify this value to adjust the importance of king safety
            }

			return score;
        }

        private List<Position> GetSurroundingPositions(Position pos)
        {
			var offsets = new (int dr, int dc)[]
			{
				(-1, -1), (-1, 0), (-1, 1),
                (0, -1),          (0, 1),
                (1, -1), (1, 0), (1, 1)

            };

			return offsets.Select(o => new Position(pos.Row + o.dr, pos.Column + o.dc)).ToList();
        }

		private int EvaluatePassedPawns(GameState state, Player player)
		{
			int score = 0;
			var positions = state.Board.PiecePositionsFor(player);

			foreach (var pos in positions)
			{
				var piece = state.Board[pos];
                if (piece.Type != PieceType.Pawn) continue;

				if (IsPassedPawn(state, pos, player))
				{
					int rank = (player == Player.White) ? pos.Row : (7 - pos.Row);
					score += (rank + 1) * 5;
                }
            }

			return score;
		}

        private bool IsPassedPawn(GameState state, Position pos, Player player)
        {
            int direction = (player == Player.White) ? 1 : -1; // 1 for White, -1 for Black

			for (int dr = 1; dr <= 6; dr++)
			{
				int r = pos.Row + dr * direction;
                if (r < 0 || r > 7) break; // out of bounds

				for (int dc = -1; dc <= 1; dc++)
				{
					int c = pos.Column + dc;
					if (c < 0 || c > 7) continue; // out of bounds

					var testPos = new Position(r, c);
					if (state.Board.HasPieceAt(testPos) &&
						state.Board[testPos].Type == PieceType.Pawn &&
						state.Board[testPos].Color == player.Opponent())
					{
						return false;
					}
                }
            }

			return true;
        }

        private bool IsWeaklyDefended(Position pos, Player color, List<Move> enemyMoves, List<Move> friendlyMoves)
		{
			bool isThreatened = enemyMoves.Any(m => m.ToPos.Equals(pos));
			bool isDefended = friendlyMoves.Any(m => m.ToPos.Equals(pos));

			int numDefenders = friendlyMoves.Count(m => m.ToPos.Equals(pos));
			return isThreatened && numDefenders <= 1;
		}

		private int GetThreatPenalty(GameState state, Position pos, Player owner, List<Move> enemyMoves, List<Move> friendlyMoves)
		{
			var piece = state.Board[pos];
			if (piece == null) return 0;

			bool isThreatened = enemyMoves.Any(m => m.ToPos.Equals(pos));
			bool isDefended = friendlyMoves.Any(m => m.ToPos.Equals(pos));

			if (!isThreatened)
				return 0;

			int value = GetPieceValue(piece.Type);
			int attackerMinValue = enemyMoves
				.Where(m => m.ToPos.Equals(pos))
				.Select(m => GetPieceValue(state.Board[m.FromPos].Type))
				.DefaultIfEmpty(1000)
				.Min();

			if (!isDefended)
				return value;

			if (attackerMinValue < value)
				return value / 2;

			return value / 4;
		}

		private bool IsThreatened(GameState state, Position pos, Player owner)
		{
			var enemyMoves = MoveGenerator.Generate(state)
				.Where(m => state.Board[m.FromPos]?.Color != owner);

			foreach (var move in enemyMoves)
			{
				if (move.ToPos.Equals(pos))
					return true;
			}
			return false;
		}


		private int GetPieceValue(PieceType type)
		{
			return type switch
			{
				PieceType.Pawn => 100,
				PieceType.Knight => 320,
				PieceType.Bishop => 330,
				PieceType.Rook => 500,
				PieceType.Queen => 900,
				PieceType.King => 20000,
				_ => 0
			};
		}

		private int GetPositionValue(PieceType type, Player player, Position pos)
		{
			int row = player == Player.White ? pos.Row : 7 - pos.Row;
			int col = pos.Column;

			switch (type)
			{
				case PieceType.Pawn:
					return row * 10;
				case PieceType.Knight:
				case PieceType.Bishop:
					return (3 - Math.Abs(3 - row)) * 4 + (3 - Math.Abs(3 - col)) * 4 + (row > 0 ? 10: 0);
				case PieceType.Rook:
					return (row == 0 || row == 7) ? 5 : 10;
				case PieceType.Queen:
					return (3 - Math.Abs(3 - row)) * 2 + (3 - Math.Abs(3 - col)) * 2;
				case PieceType.King:
					return row < 2 ? 30 : 0;
				default:
					return 0;

			}

		}

		private int EvaluateCenterControl(PieceType type, Position pos)
		{
			if (type == PieceType.Pawn || type == PieceType.Knight || type == PieceType.Bishop)
			{
				if ((pos.Row == 3 || pos.Row == 4) && (pos.Column == 3 || pos.Column == 4)) // d4, e4, d5, e5
					return 20;
			}
			return 0;
		}

		private int EvaluateKingSafety(PieceType type, Player color, Position pos)
		{
			if (type != PieceType.King) return 0;

			// Nếu vua còn ở vị trí bắt đầu thì phạt điểm
			if ((color == Player.White && pos.Row == 0 && pos.Column == 4) ||
				(color == Player.Black && pos.Row == 7 && pos.Column == 4))
			{
				return -30;
			}

			return 0;
		}

		private int EvaluateDevelopment(PieceType type, Player color, Position pos)
		{
			int score = 0;

			int startingRow = color == Player.White ? 0 : 7;
			int row = pos.Row;
			int col = pos.Column;

			//bool isDeveloped = (color == Player.White && row >= 3) || (color == Player.Black && row <= 4);

			if (type == PieceType.Knight)
			{
				if ((color == Player.White && row > 1) || (color == Player.Black && row < 6))
					score += 20;

				if (row == startingRow && (col == 1 || col == 6))
					score -= 10;
			}

			if (type == PieceType.Bishop)
			{
				if ((color == Player.White && row > 1) || (color == Player.Black && row < 6))
					score += 20;

				if (row == startingRow && (col == 2 || col == 5))
					score -= 10;
			}

			if (type == PieceType.Rook)
			{
				if ((color == Player.White && row > 0) || (color == Player.Black && row < 7))
					score += 10;
			}

			if (type == PieceType.Queen)
			{
				bool isEarly = color == Player.White ? row <= 2: row >= 5;

				if (isEarly)
					score -= 30;

				var enemyMoves = MoveGenerator.GenerateForPlayer(currentState, color.Opponent());

                bool isThreatened = enemyMoves.Any(m => m.ToPos.Equals(pos));

				if (isThreatened)
					score -= 40;
			}

			if (type == PieceType.Pawn)
			{
				int advance = color == Player.White ? 7 - row : row;
				score += advance * 2;

				if ((col >= 2 && col <= 5) && ((color == Player.White && row >= 3) || (color == Player.Black && row <= 4)))
					score += 5;
			}

			return score;
		}

		private int GetDenfenseBonus(Position pos, Player owner, List<Move> friendlyMoves, GameState state)
		{
			int bonus = 0;

			foreach (var move in friendlyMoves)
			{
				if (move.ToPos.Equals(pos))
				{
					var defender = state.Board[move.FromPos];
                    if (defender != null && defender.Color == owner)
					{
						bonus += GetPieceValue(defender.Type) / 10;	
                    }
                }
			}

			return bonus;
        }

		private int EvaluateKingSafety(GameState state, Player color)
        {
			Position kingPos = FindKingPosition(state, color);

			if (kingPos == null) return 0;

			var surrounding = GetSurroundingSquares(kingPos);
			var enemyMoves = MoveGenerator.GenerateForPlayer(state, color.Opponent())
				.Select(m => m.ToPos).ToHashSet();

			int dangerCount = surrounding.Count(p => enemyMoves.Contains(p));

			int score = -dangerCount * 15;

			bool hasCastled = color == Player.White ?
				!kingPos.Equals(new Position(7, 4)) : //e1
                !kingPos.Equals(new Position(0, 4)); // e8

			if (!hasCastled)
				score -= 30;

			return score;
        }


        private Position FindKingPosition(GameState state, Player player)
        {
			foreach ( var pos in state.Board.PiecePositionsFor(player))
			{
				var piece = state.Board[pos];

                if (piece.Type == PieceType.King)
                {
					return pos;
                }
            }

			return new Position(-1, -1); // king not found
        }

		private List<Position> GetSurroundingSquares(Position pos)
		{
			var offsets = new (int dr, int dc)[]
			{
				(-1, -1), (-1, 0), (-1, 1),
				(0, -1),          (0, 1),
				(1, -1), (1, 0), (1, 1),
			};

			var result = new List<Position>();
			foreach (var (dr, dc) in offsets)
			{
				int r = pos.Row + dr, c = pos.Column + dc;
				if (r >= 0 && r < 8 && c >= 0 && c < 8)
                    result.Add(new Position(r, c));
            }

            return result;
        }

		private int EvaluateMobility(GameState state)
		{
			int whiteMoves = MoveGenerator.GenerateForPlayer(state, Player.White).Count();
            int blackMoves = MoveGenerator.GenerateForPlayer(state, Player.Black).Count();

			return (whiteMoves - blackMoves) * 2;
        }

		private int EvaluatePawnStructure(GameState state, Player color)
		{
			var pawns = GetPiecePosition(state, color, PieceType.Pawn);
			var pawnCols = pawns.GroupBy(p => p.Column).ToDictionary(g => g.Key, g => g.ToList());

			int penalty = 0;

			for (int col = 0; col < 8; col++)
			{
				if (!pawnCols.ContainsKey(col)) continue;

				if (pawnCols[col].Count() > 1)
					penalty -= 10 * (pawnCols[col].Count() - 1);

				bool leftHas = pawnCols.ContainsKey(col - 1);
                bool rightHas = pawnCols.ContainsKey(col + 1);
				
				if (!leftHas && !rightHas) penalty -= 15;
            }

			penalty += EvaluatePassedPawns(state, color);

            return penalty;
        }

        private List<Position> GetPiecePosition(GameState state, Player color, PieceType type)
        {
            var result = new List<Position>();
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var piece = state.Board[r, c];
                    if (piece?.Color == color && piece.Type == type)
                    {
                        result.Add(new Position(r, c));
                    }
                }
            }
			return result;
        }

		private double GetGamePhase(GameState state)
		{
			int phase = 0;
			for (int r = 0; r < 8; r++)
				for (int c = 0; c < 8; c++)
				{
					var p = state.Board[r, c];

					if (p ==   null) continue;

					if (p.Type == PieceType.Queen) phase += 4;
					else if (p.Type == PieceType.Rook) phase += 2;
					else if (p.Type == PieceType.Bishop || p.Type == PieceType.Knight) phase += 1;
                }

			return Math.Clamp(1.0 - phase / 32.0, 0, 1);
        }
    }
}
