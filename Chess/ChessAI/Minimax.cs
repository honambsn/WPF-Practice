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

	private readonly bool _useMoveOrdering;
	private readonly bool _useTT;
	//private readonly int _timeLimitMs;
	private readonly Dictionary<ulong, int> _transpositionTable = new();

    public Minimax(Evaluator evaluator, bool useMoveOrdering, bool useTT, int timeLimitMs)

    {
        _evaluator = evaluator;
        _useMoveOrdering = useMoveOrdering;
        _useTT = useTT;
        _timeLimit = TimeSpan.FromMilliseconds(timeLimitMs);
    }

	public int Search(GameState state, int depth, int alpha, int beta, bool maximizingPlayer, DateTime startTime)
	{
		if(DateTime.Now - startTime > _timeLimit)
		{
			return _evaluator.EvaluateBoard(state);
		}

		if (depth == 0 || state.IsGameOver())
		{
			return _evaluator.EvaluateBoard(state);
		}

		if (_useTT)
		{
			ulong key = state.ZobristKey;
			if (_transpositionTable.TryGetValue(key, out int cachedEval))
				return cachedEval;
		}

		List<Move> moves = MoveGenerator.Generate(state).ToList();

		//var moves = MoveGenerator.Generate(state);
		if (_useMoveOrdering)
		{
            moves = moves.OrderByDescending(m =>
            {
                Piece target = state.Board[m.ToPos];
                return target == null ? 0 : (int)target.Type;
            }).ToList();

        }

  //      if (depth > 2)
		//{
		//	moves = MoveGenerator.Generate(state).ToList();
		//}
		//else
		//{
		//	moves = MoveGenerator.Generate(state)
		//		.Where(m => state.Board[m.ToPos] != null)
		//		.ToList();
		//}

		int bestEval =  maximizingPlayer ? int.MinValue : int.MaxValue;

		foreach(var move in moves)
		{
			state.ApplyMove(move);
            int eval = Search(state, depth - 1, alpha, beta, !maximizingPlayer, startTime);
			state.UndoMove();

			if (maximizingPlayer)
			{
				bestEval = Math.Max(bestEval, eval);
				alpha = Math.Max(alpha, eval);
            }
			else
            {
                bestEval = Math.Min(bestEval, eval);
                beta = Math.Min(beta, eval);
            }

            if (beta <= alpha)
				break;
        }

		if (_useTT)
		{
			ulong key = state.ZobristKey;
            _transpositionTable[key] = bestEval;
        }


        #region old ver
        //if (moves.Count == 0)
        //{
        //    return _evaluator.EvaluateBoard(state);
        //}

        //if (maximizingPlayer)
        //{
        //    int maxEval = int.MinValue;
        //    foreach (var move in moves)
        //    {
        //        //var next = state.Copy();
        //        //next.ApplyMove(move);

        //        state.ApplyMove(move);

        //        int eval = Search(state, depth - 1, alpha, beta, false, startTime);

        //        state.UndoMove();

        //        maxEval = Math.Max(maxEval, eval);
        //        alpha = Math.Max(alpha, eval);
        //        if (beta <= alpha)
        //            break;
        //    }
        //    return maxEval;
        //}
        //else
        //{
        //    int minEval = int.MaxValue;
        //    foreach (var move in moves)
        //    {
        //        //var next = state.Copy();
        //        //next.ApplyMove(move);
        //        state.ApplyMove(move);

        //        int eval = Search(state, depth - 1, alpha, beta, true, startTime);
        //        state.UndoMove();

        //        minEval = Math.Min(minEval, eval);
        //        beta = Math.Min(beta, eval);
        //        if (beta <= alpha)
        //            break;
        //    }
        //    return minEval;
        //}

        #endregion
        return bestEval;
    }
}