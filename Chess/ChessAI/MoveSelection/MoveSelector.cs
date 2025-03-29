using ChessAI.Algorithms;
using ChessAI.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.MoveSelection
{
	public class MoveSelector
	{
		private readonly Evaluation evaluator;
		private readonly Random random;

		public MoveSelector(Evaluation evaluation)
		{
			evaluator = evaluation;
			random = new Random();
		}

		public Move SelectMove(GameState gameState, BotDifficulty difficulty)
		{
			return difficulty switch
			{
				BotDifficulty.Easy => SelectRandomMove(gameState),
				BotDifficulty.Medium => SelectMediumMove(gameState),
				BotDifficulty.Hard => SelectHardMove(gameState),
				BotDifficulty.Expert => SelectExpertMove(gameState),
				_ => SelectRandomMove(gameState)
			};
		}

		private Move SelectRandomMove(GameState gameState)
		{
			var legalMoves = gameState.GetAllLegalMoves();
			return legalMoves[random.Next(legalMoves.Count)];
		}

		private Move SelectMediumMove(GameState gameState)
		{
			var minimax = new Minimax(BotDifficulty.Medium);
			return minimax.GetBestMove(gameState);
		}

		private Move SelectHardMove(GameState gameState)
		{
			var minimax = new Minimax(BotDifficulty.Hard);
			return minimax.GetBestMove(gameState);
		}

		private Move SelectExpertMove(GameState gameState)
		{
			var minimax = new Minimax(BotDifficulty.Expert);
			return minimax.GetBestMove(gameState);
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
