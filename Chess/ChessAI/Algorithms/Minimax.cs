using ChessAI.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;
using ChessAI.Evaluation;



namespace ChessAI.Algorithms
{
	public class Minimax
	{
		private int _depth;
		private readonly BoardEvaluator evaluator;
		private readonly Random random = new Random();


		public Minimax(BotDifficulty difficulty, BoardEvaluator evaluator)
		{
			this.evaluator = evaluator;
			_depth = difficulty switch
			{
				BotDifficulty.Easy => 2,
				BotDifficulty.Medium => 3,
				BotDifficulty.Hard => 4,
				BotDifficulty.Expert => 6,
				_ => 3
			};
		}

		public IEnumerable<Move> GetBestMoves(GameState gameState)
		{
			int bestValue = int.MinValue;
			List<Move> bestMoves = new List<Move>();

			foreach (var move in gameState.Board.PiecePositions().SelectMany(pos => gameState.Board[pos].GetMoves(pos, gameState.Board)).Where(move => move.IsLegal(gameState.Board)))
			{
				gameState.ApplyMove(move);
				int moveValue = MinimaxSearch(gameState, _depth, int.MinValue, int.MaxValue, false);
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

		public Move? GetBestMove(GameState gameState)
		{
			var bestMoves = GetBestMoves(gameState).ToList();
			return bestMoves.Count > 0 ? bestMoves[random.Next(bestMoves.Count)] : null;
		}

		private int MinimaxSearch(GameState state, int depth, int alpha, int beta, bool isMaximizing)
		{
			if (depth == 0 || state.IsGameOver())
			{
				return evaluator.Evaluate(state);
			}

			if (isMaximizing)
			{
				int maxEval = int.MinValue;
				foreach (var move in state.Board.PiecePositions().SelectMany(pos => state.Board[pos].GetMoves(pos, state.Board)).Where(move => move.IsLegal(state.Board)))
				{
					state.ApplyMove(move);
					int eval = MinimaxSearch(state, depth - 1, alpha, beta, false);
					state.UndoMove(move);
					maxEval = Math.Max(maxEval, eval);
					alpha = Math.Max(alpha, eval);
					if (beta <= alpha)
					{
						break;
					}
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
					if (beta <= alpha)
					{
						break;
					}
				}
				return minEval;
			}
		}
	}
}
