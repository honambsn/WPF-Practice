using ChessAI.Config;
using ChessAI.Interfaces;
using ChessAI.MoveSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
	public class AIPlayer : IChessAI
	{
		private readonly MoveSelector _moveSelector;
		private BotDifficulty difficulty;
		private readonly Evaluation evaluator;

		public AIPlayer(BotDifficulty initialDifficulty =  BotDifficulty.Easy)
		{
			_moveSelector = new MoveSelector();

		}

	}
}
