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

	public Bot(BotDifficulty difficulty)
	{
		_depth = difficulty switch
		{
			BotDifficulty.Easy => 1,
			BotDifficulty.Medium => 2,
			BotDifficulty.Hard => 3,
			_ => 2
		};

		_evaluator = new Evaluator();
		_minimax = new Minimax(_evaluator);
	}

	public Move GetBestMove(GameState state)
	{
		var moves = MoveGenerator.Generate(state);
		Move bestMove = null;
		int bestScore = int.MinValue;

		foreach (var move in moves)
		{
			var copy = state.Copy();
			copy.ApplyMove(move);
			int score = _minimax.Search(copy, _depth - 1, int.MinValue, int.MaxValue, false);

			if (score > bestScore)
			{
				bestScore = score;
				bestMove = move;
			}
		}

		return bestMove;
	}
}
