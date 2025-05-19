using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

					if (IsWeaklyDefended(pos, piece.Color, enemyMoves, friendlyMoves))
					{
						defensePenaltyScore -= sign * 30; // có thể tùy chỉnh mức phạt
					}


				}
			}

			return materialScore + centerControlScore + kingSafetyScore + developmentScore + threatPenaltyScore * 2 + defensePenaltyScore;
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

				var enemyMoves = MoveGenerator.GenerateForPlayer(GameState.Instance, color.Opponent());

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



	}
}
