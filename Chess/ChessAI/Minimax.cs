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
	private DateTime _startTime;
	private TimeSpan _timeLimit;

	public Minimax(Evaluator evaluator)
	{
		_evaluator = evaluator;
	}

	public int Search(GameState state, int depth, int alpha, int beta, bool maximizingPlayer, DateTime startTime, TimeSpan timeLimit)
	{
		if(DateTime.Now - startTime > timeLimit)
		{
			return _evaluator.EvaluateBoard(state);
		}

		if (depth == 0 || state.IsGameOver())
		{
			return _evaluator.EvaluateBoard(state);
		}

		List<Move> moves;

		//var moves = MoveGenerator.Generate(state);

		if (depth > 2)
		{
			moves = MoveGenerator.Generate(state).ToList();
		}
		else
		{
			moves = MoveGenerator.Generate(state)
				.Where(m => state.Board[m.ToPos] != null)
				.ToList();
		}

		if (moves.Count == 0)
		{
			return _evaluator.EvaluateBoard(state);
		}

		if (maximizingPlayer)
		{
			int maxEval = int.MinValue;
			foreach (var move in moves)
			{
				//var next = state.Copy();
				//next.ApplyMove(move);

				state.ApplyMove(move);

				int eval = Search(state, depth - 1, alpha, beta, false, startTime, timeLimit);

				state.UndoMove();

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
				//var next = state.Copy();
				//next.ApplyMove(move);
				state.ApplyMove(move);

				int eval = Search(state, depth - 1, alpha, beta, true, startTime, timeLimit);
				state.UndoMove();

				minEval = Math.Min(minEval, eval);
				beta = Math.Min(beta, eval);
				if (beta <= alpha)
					break;
			}
			return minEval;
		}
	}
}