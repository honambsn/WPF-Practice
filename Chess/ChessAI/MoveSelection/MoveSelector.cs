using ChessLogic;
using ChessInterfaces;
using System.Linq;
using ChessAI.Algorithms;
using ChessAI.Config;
using ChessAI.Evaluation;

namespace ChessAI.MoveSelection
{
	public interface IMoveStrategy
	{
		Move? SelectMove(IGameState gameState);
	}

	public class EasyMoveStrategy : IMoveStrategy
	{
		private readonly Random random = new Random();

		public Move? SelectMove(IGameState gameState)
		{
			var legalMoves = gameState.GetAllLegalMoves().ToList();
			return legalMoves.Count > 0 ? legalMoves[random.Next(legalMoves.Count)] : null;
		}
	}

	public class MinimaxMoveStrategy : IMoveStrategy
	{
		private readonly Minimax minimax;

		public MinimaxMoveStrategy(BotDifficulty difficulty, BoardEvaluator evaluator)
		{
			this.minimax = new Minimax(difficulty, evaluator);
		}

		public Move? SelectMove(IGameState gameState)
		{
			return minimax.GetBestMove(gameState);
		}
	}

	public class MoveSelector
	{
		private readonly IMoveStrategy moveStrategy;

		public MoveSelector(BotDifficulty difficulty, BoardEvaluator evaluator)
		{
			moveStrategy = difficulty switch
			{
				BotDifficulty.Easy => new EasyMoveStrategy(),
				_ => new MinimaxMoveStrategy(difficulty, evaluator)
			};
		}

		public Move? SelectMove(IGameState gameState)
		{
			return moveStrategy.SelectMove(gameState);
		}
	}
}
