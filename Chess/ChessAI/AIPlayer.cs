using ChessAI.Algorithms;
using ChessAI.Config;
using ChessAI.Evaluation;
using ChessAI.Interfaces;
using ChessAI.MoveSelection;
using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
	public class AIPlayer : IChessAI
	{
		private readonly MoveSelector moveSelector;
		private readonly BoardEvaluator evaluator;
		private BotDifficulty difficulty;

		public AIPlayer(BotDifficulty initialDifficulty = BotDifficulty.Medium)
		{
			evaluator = new BoardEvaluator();
			moveSelector = new MoveSelector(initialDifficulty, evaluator);
			difficulty = initialDifficulty;
		}
		public Move? GetBestMove(GameState gameState)
		{
			return moveSelector.SelectMove(gameState);
		}

		public IEnumerable<Move> GetBestMoves(GameState gameState)
		{
			return new Minimax(difficulty, evaluator).GetBestMoves(gameState);
		}

		public void SetDifficulty(BotDifficulty newdifficulty)
		{
			difficulty = newdifficulty;
		}

		public (Move? BestMove, int Evaluation) GetDetailedMove(GameState gameState)
		{
			var bestMove = GetBestMove(gameState);
			if (bestMove == null)
			{
				return (null, 0);
			}

			gameState.ApplyMove(bestMove);
			int evaluation = evaluator.Evaluate(gameState);
			gameState.UndoMove(bestMove);
			return (bestMove, evaluation);
		}
	}
}
