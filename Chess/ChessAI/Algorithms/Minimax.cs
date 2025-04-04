using ChessAI.Config;
using ChessAI.Evaluation;
using ChessInterfaces;
using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessAI.Algorithms
{
	public class Minimax
	{
		private int depth;
		private readonly BoardEvaluator evaluator;
		private readonly Random random = new Random();

		public Minimax(BotDifficulty difficulty, BoardEvaluator evaluator)
		{
			this.evaluator = evaluator;
			depth = difficulty switch
			{
				BotDifficulty.Easy => 2,
				BotDifficulty.Medium => 3,
				BotDifficulty.Hard => 4,
				BotDifficulty.Expert => 6,
				_ => 3
			};
		}

		public IEnumerable<Move> GetBestMoves(IGameState gameState)
		{
			int bestValue = int.MinValue;
			List<Move> bestMoves = new List<Move>();

			foreach (var move in gameState.GetAllLegalMoves())
			{
				gameState.ApplyMove(move);
				int moveValue = MinimaxSearch(gameState, depth, int.MinValue, int.MaxValue, false);
				gameState.UndoMove(move);

				if (moveValue > bestValue)
				{
					bestValue = moveValue;
					bestMoves.Clear();
					bestMoves.Add(move);
				}
				else if (moveValue == bestValue)
				{
					bestMoves.Add(move);
				}
			}

			return bestMoves;
		}

		public Move? GetBestMove(IGameState gameState)
		{
			var bestMoves = GetBestMoves(gameState).ToList();
			return bestMoves.Count > 0 ? bestMoves[random.Next(bestMoves.Count)] : null;
		}

		private int MinimaxSearch(IGameState state, int depth, int alpha, int beta, bool isMaximizing)
		{
			if (depth == 0 || state.IsGameOver2())
				return evaluator.Evaluate(state);

			if (isMaximizing)
			{
				int maxEval = int.MinValue;
				foreach (var move in state.GetAllLegalMoves())
				{
					state.ApplyMove(move);
					int eval = MinimaxSearch(state, depth - 1, alpha, beta, false);
					state.UndoMove(move);
					maxEval = Math.Max(maxEval, eval);
					alpha = Math.Max(alpha, eval);
					if (beta <= alpha) break;
				}
				return maxEval;
			}
			else
			{
				int minEval = int.MaxValue;
				foreach (var move in state.GetAllLegalMoves())
				{
					state.ApplyMove(move);
					int eval = MinimaxSearch(state, depth - 1, alpha, beta, true);
					state.UndoMove(move);
					minEval = Math.Min(minEval, eval);
					beta = Math.Min(beta, eval);
					if (beta <= alpha) break;
				}
				return minEval;
			}
		}
	}
}
