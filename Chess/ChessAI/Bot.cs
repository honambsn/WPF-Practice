using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
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
			BotDifficulty.Random => 0,
			BotDifficulty.Easy => 2,
			BotDifficulty.Medium => 3,
			BotDifficulty.Hard => 4,
			_ => 3
		};

		_evaluator = new Evaluator();
		_minimax = new Minimax(_evaluator);
	}

	public Move GetBestMove(GameState state)
	{
		var moves = MoveGenerator.Generate(state).ToList();

		if (_difficulty == BotDifficulty.Random)
		{
			return moves[_random.Next(moves.Count)];
		}

		Move bestMove = null;
		int bestScore = int.MinValue;
		var seenBoards = new HashSet<string>();

		foreach (var move in moves)
		{
			var copy = state.Copy();
			copy.ApplyMove(move);
			string boardKey = copy.Board.ToString();
			
			if (seenBoards.Contains(boardKey))
			{
				continue; // Skip already evaluated boards
			}
			
			int score = _minimax.Search(copy, _depth - 1, int.MinValue, int.MaxValue, false);

			if (score > bestScore || bestMove == null)
			{
				bestScore = score;
				bestMove = move;
			}
		}

		return bestMove;
	}
}
