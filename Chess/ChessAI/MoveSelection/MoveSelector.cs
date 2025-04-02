using ChessAI.Algorithms;
using ChessAI.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;
using ChessAI.Evaluation;
namespace ChessAI.MoveSelection
{
	public class MoveSelector
	{
		private readonly BoardEvaluator evaluator;
		private readonly Minimax minimax;
		private readonly Random random = new Random();

		public MoveSelector(BoardEvaluator evaluator, BotDifficulty difficulty)
		{
			this.evaluator = evaluator;
			this.minimax = new Minimax(difficulty, evaluator);
		}

		public Move? SelectMove(GameState gameState, BotDifficulty difficulty)
		{
			if (difficulty == BotDifficulty.Easy)
			{
				return SelectRandomMove(gameState);
			}
			else
			{
				return minimax.GetBestMove(gameState);
			}
		}

		private Move? SelectRandomMove(GameState gameState)
		{
			var legalMoves = gameState.GetAllLegalMoves().ToList();
			return legalMoves.Count > 0 ? legalMoves[random.Next(legalMoves.Count)] : null;
		}

		public List<Move> GetTopCandidateMoves(GameState gameState, int topCount)
		{
			var legalMoves = gameState.GetAllLegalMoves();
			return legalMoves
				.Select(move => {
					var newState = gameState.Copy();
					newState.ApplyMove(move);
					return (Move: move, Score: evaluator.Evaluate(newState));
				})
				.OrderByDescending(x => x.Score)
				.Take(topCount)
				.Select(x => x.Move)
				.ToList();
		}
	}

}
