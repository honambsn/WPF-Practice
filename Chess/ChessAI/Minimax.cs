using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;
using System;
using ChessAI;

public class Minimax
{
	private readonly Evaluator _evaluator;

	public Minimax(Evaluator evaluator)
	{
		_evaluator = evaluator;
	}

	public int Search(GameState state, int depth, int alpha, int beta, bool maximizingPlayer)
	{
		if (depth == 0 || state.IsGameOver())
		{
			return _evaluator.EvaluateBoard(state);
		}

		var moves = MoveGenerator.Generate(state);

		if (maximizingPlayer)
		{
			int maxEval = int.MinValue;
			foreach (var move in moves)
			{
				var next = state.Copy();
				next.ApplyMove(move);
				int eval = Search(next, depth - 1, alpha, beta, false);
				maxEval = Math.Max(maxEval, eval);
				alpha = Math.Max(alpha, eval);
				if (beta <= alpha)
					break;
			}
			return maxEval;
		}
		else
		{
			int minEval = int.MaxValue;
			foreach (var move in moves)
			{
				var next = state.Copy();
				next.ApplyMove(move);
				int eval = Search(next, depth - 1, alpha, beta, true);
				minEval = Math.Min(minEval, eval);
				beta = Math.Min(beta, eval);
				if (beta <= alpha)
					break;
			}
			return minEval;
		}
	}
}