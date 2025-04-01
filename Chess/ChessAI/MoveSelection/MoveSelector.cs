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
		private readonly Random random;

		public MoveSelector(BoardEvaluator evaluator, BotDifficulty difficulty)
		{
			this.evaluator = evaluator;
			this.minimax = new Minimax(difficulty, evaluator);
			this.random = new Random();
		}

		public Move SelectMove(GameState gameState, BotDifficulty difficulty)
		{
			return difficulty switch
			{
				BotDifficulty.Easy => SelectRandomMove(gameState),
				BotDifficulty.Medium => minimax.GetBestMove(gameState),
				BotDifficulty.Hard => minimax.GetBestMove(gameState),
				BotDifficulty.Expert => minimax.GetBestMove(gameState),
				_ => SelectRandomMove(gameState)
			};
		}

		private Move SelectRandomMove(GameState gameState)
		{
			var legalMoves = gameState.GetAllLegalMoves();
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
