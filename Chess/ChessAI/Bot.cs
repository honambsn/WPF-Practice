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

		//if (_difficulty == BotDifficulty.Random)
		//{
		//	return moves[_random.Next(moves.Count)];
		//}

		Move bestMove = null;
		int bestScore = int.MinValue;
		var seenBoards = new HashSet<string>();
		var startTime = DateTime.Now;
		var timeLimit = TimeSpan.FromSeconds(10); // 10s for each move


		//foreach (var move in scoredMoves)
		//{
		//	var copy = state.Copy();
		//	copy.ApplyMove(move);
		//	string boardKey = copy.Board.ToString();

		//	if (seenBoards.Contains(boardKey))
		//	{
		//		continue;			}

		//	int score = _minimax.Search(copy, _depth - 1, int.MinValue, int.MaxValue, false, startTime, timeLimit);

		//	if (score > bestScore || bestMove == null)
		//	{
		//		bestScore = score;
		//		bestMove = move;
		//	}
		//}


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

	private int ScoreMove(GameState state, Move move)
	{
		var fromPiece = state.Board[move.FromPos];
		var toPiece = state.Board[move.ToPos];

		int score = 0;

		if (toPiece != null)
		{
			// Ăn quân: điểm cao hơn nếu ăn quân giá trị lớn
			score += GetPieceValue(toPiece.Type) * 10 - GetPieceValue(fromPiece.Type);
		}

		if (IsPromotion(state, move))
		{
			score += 800; // Phong hậu
		}

		if (IsCheck(state, move))
		{
			score += 50; // Chiếu vua
		}

		return score;
	}

}
