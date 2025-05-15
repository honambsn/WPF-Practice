using ChessLogic;
using ChessAI;

public class Bot
{
	private readonly Minimax _minimax;
	private readonly Evaluator _evaluator;
	private readonly int _depth;
	private readonly BotDifficulty _difficulty;
	private readonly Random _random = new Random();

	public Bot(BotDifficulty difficulty)
	{
		_difficulty = difficulty;
		_depth = difficulty switch
		{
			
			BotDifficulty.Easy => 2,
			BotDifficulty.Medium => 3,
			BotDifficulty.Hard => 20,
			_ => 3
		};

		_evaluator = new Evaluator();
		_minimax = new Minimax(_evaluator);
	}

	public Move GetBestMove(GameState state)
	{
		var moves = MoveGenerator.Generate(state).ToList();
		if (!moves.Any())
		{
			return null; // Không có nước đi hợp lệ
		} 

		// Gán điểm ưu tiên cho từng nước đi
		var scoredMoves = moves.Select(move => new { Move = move, Score = ScoreMove(state, move) })
							   .OrderByDescending(x => x.Score) // Sắp xếp giảm dần
							   .Select(x => x.Move)
							   .ToList();


		Move bestMove = null;
		int bestScore = int.MinValue;
		var seenBoards = new HashSet<string>();
		var startTime = DateTime.Now;
		var timeLimit = TimeSpan.FromSeconds(10); // 10s for each move

		// new logic for parallel processing to speed up the search
		object lockObj = new();
		Parallel.ForEach(scoredMoves, move =>
		{
			var copy = state.Copy();
			copy.ApplyMove(move);
			string boardKey = copy.Board.ToString();

			lock (lockObj)
			{
				if (seenBoards.Contains(boardKey)) return;
				seenBoards.Add(boardKey);
			}

			int score = _minimax.Search(copy, _depth - 1, int.MinValue, int.MaxValue, false, startTime, timeLimit);

			lock (lockObj)
			{
				if (score > bestScore)
				{
					bestScore = score;
					bestMove = move;
				}
			}
		});


		return bestMove;
	}

	private bool IsPromotion(GameState state, Move move)
	{
		var piece = state.Board[move.FromPos];
		return piece.Type == PieceType.Pawn &&
			   ((piece.Color == Player.White && move.ToPos.Row == 0) ||
				(piece.Color == Player.Black && move.ToPos.Row == 7));
	}

	private bool IsCheck(GameState state, Move move)
	{
		var copy = state.Copy();
		copy.ApplyMove(move);
		return copy.Board.IsInCheck(copy.CurrentPlayer);// Sau khi đổi lượt, kiểm tra có chiếu vua đối thủ không
	}



	private int GetMovePriority(GameState state, Move move)
	{
		var piece = state.Board[move.FromPos];
		var targetPiece = state.Board[move.ToPos];

		int priority = 0;

		// Ưu tiên ăn quân
		if (targetPiece != null)
		{
			priority += 10 * GetPieceValue(targetPiece.Type) - GetPieceValue(piece.Type);
		}

		// Ưu tiên phong hậu
		if (IsPromotion(state, move))
		{
			priority += 800;
		}

		// Ưu tiên chiếu vua
		if (IsCheck(state, move))
		{
			priority += 50;
		}

		return priority;
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

	private bool IsKingThreatened(GameState state, Player player, List<Move> enemyMoves)
	{
		var kingPos = state.Board.PiecePositionsFor(player)
						.FirstOrDefault(p => state.Board[p]?.Type == PieceType.King);

		return enemyMoves.Any(m => m.ToPos == kingPos);
	}


	private int ScoreMove(GameState state, Move move)
	{
		var fromPiece = state.Board[move.FromPos];
		var toPiece = state.Board[move.ToPos];

		int score = 0;

		// capture piece
		if (toPiece != null)
		{
			score += GetPieceValue(toPiece.Type) * 10 - GetPieceValue(fromPiece.Type);
		}


		// check for promotion queen
		if (IsPromotion(state, move))
		{
			if (!IsUnderThreat(state, move.ToPos, fromPiece.Color))
			{
				score += 800;
			}
			else
			{
				score += 200;
			}
		}

		// check
		if (IsCheck(state, move))
		{
			score += 50;
		}

		// central square
		if (IsCentralSquare(move.ToPos))
		{
			score += 20;
		}

		// development	
		if (IsPieceDeveloping(fromPiece, move.FromPos, move.ToPos))
		{
			score += 30;
		}

		// pawn dev
		if (fromPiece.Type == PieceType.Pawn)
		{
			int advance = fromPiece.Color == Player.White
				? move.FromPos.Row - move.ToPos.Row
				: move.ToPos.Row - move.FromPos.Row;
			
			score += advance * 10;

			bool isInitialDoublePush = (fromPiece.Color == Player.White && move.FromPos.Row == 6 && move.ToPos.Row == 4) ||
				(fromPiece.Color == Player.Black && move.FromPos.Row == 1 && move.ToPos.Row == 3);

			if (isInitialDoublePush)
				score += 15;

			if (move.ToPos.Column == 3 || move.ToPos.Column == 4)
				score += 20;

			//if (IsSquareThreatened(state, move.ToPos, fromPiece.Color.Opponent()))
			if (IsSquareThreatened(state, move.ToPos, fromPiece.Color))
			{
				score -= 15;
			}

			//Console.WriteLine($"Pawn move {move.FromPos} -> {move.ToPos}, score = {score}");

		}

		//castling
		if (fromPiece.Type == PieceType.Knight && Math.Abs(move.ToPos.Column - move.FromPos.Column) == 2)
		{
			score += 60;
		}

		if (move.FromPos.Equals(move.ToPos))
        {
			score -= 100;
        }

		if ((fromPiece.Type == PieceType.Rook || fromPiece.Type == PieceType.Knight) &&
			move.ToPos == move.FromPos)
		{
			score -= 50;
		}
		
		if (fromPiece.Type == PieceType.Knight || fromPiece.Type == PieceType.Bishop)
		{
			if (IsBackToStartingPosition(fromPiece, move.FromPos))
			{
				score -= 40;
			}
		}

		if (IsUnderThreat(state, move.ToPos, fromPiece.Color))
		{
			score -= GetPieceValue(fromPiece.Type) / 2;
		}

		if (IsUnderThreat(state, move.FromPos, fromPiece.Color))
		{
			score += GetPieceValue(fromPiece.Type) / 3;
		}

		var copy = state.Copy();
		copy.ApplyMove(move);

		var currentPlayer = copy.CurrentPlayer;
		var enemyMoves = MoveGenerator.GenerateForPlayer(copy, currentPlayer.Opponent()).ToList();

		if (!IsKingThreatened(copy, currentPlayer, enemyMoves))
		{
			var wasInCheck = IsKingThreatened(state, currentPlayer, enemyMoves);
			if (wasInCheck)
			{
				score += 200;
			}
		}
		return score;
	}

	private bool IsSquareThreatened(GameState state, Position toPos, Player color)
	{
		foreach (var move in MoveGenerator.Generate(state))
		{
			if (move.ToPos.Equals(toPos) && state.Board[move.FromPos]?.Color != color.Opponent())
			{
				return true;
			}
		}
		return false;
	}

	private bool IsCentralSquare(Position pos)
	{
		return (pos.Row >= 2 && pos.Row <= 5) && (pos.Column >= 2 && pos.Column <= 5);
	}

	private bool IsPieceDeveloping(Piece piece, Position fromPos, Position toPos)
	{
		if (piece.Type == PieceType.Knight || piece.Type == PieceType.Bishop)
		{
			if (piece.Color == Player.White)
			{
				return fromPos.Row == 7 && toPos.Row <= 5;
			}
			else
			{
				return fromPos.Row == 0 && toPos.Row >= 2;
			}
		}

		if (piece.Type == PieceType.Rook)
		{
			if (piece.Color == Player.White)
			{
				return fromPos.Row == 7 && (fromPos.Column == 0 || fromPos.Column == 7) && toPos.Row <= 5;
			}
			else
			{
				return fromPos.Row == 0 && (fromPos.Column == 0 || fromPos.Column == 7) && toPos.Row >= 2;		
			}
		}

		return false;
	}

	private bool IsBackToStartingPosition(Piece piece, Position toPos)
	{
		if (piece.Type == PieceType.Knight)
		{
			return (piece.Color == Player.White && (toPos.Row == 7 && (toPos.Column == 1 || toPos.Column == 6))) ||
				   (piece.Color == Player.Black && (toPos.Row == 0 && (toPos.Column == 1 || toPos.Column == 6)));
		}

		if (piece.Type == PieceType.Bishop)
		{
			return (piece.Color == Player.White && (toPos.Row == 7 && (toPos.Column == 2 || toPos.Column == 5))) ||
				   (piece.Color == Player.Black && (toPos.Row == 0 && (toPos.Column == 2 || toPos.Column == 5)));
		}

		return false;
	}

	private bool IsUnderThreat(GameState state, Position pos, Player def)
	{
		var opponentMoves = MoveGenerator.Generate(state)
			.Where(m => state.Board[m.FromPos]?.Color != def);

		return opponentMoves.Any(m => m.ToPos.Equals(pos));
	}
}
