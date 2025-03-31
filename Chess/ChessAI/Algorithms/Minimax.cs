using ChessAI.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;

namespace ChessAI.Algorithms
{
	public class Minimax
	{
		private int _depth;
		private readonly BoardEvaluator evaluator;

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

		public IEnumerable<Move> GetBestMove(GameState gameState)
		{
			int besValue = int.MinValue;
			Move bestMove = null;
			yield return bestMove;
		}
	}
}
