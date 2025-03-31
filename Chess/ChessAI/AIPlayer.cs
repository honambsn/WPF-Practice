using ChessAI.Config;
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
	public interface AIPlayer : IChessAI
	{
		Move GetBestMove(GameState gameState);
		IEnumerable<Move> GetBestMoves(GameState gameState);
		void SetDifficulty(BotDifficulty difficulty);
		(Move BestMove, int Evaluation) GetDetailedMove(GameState gameState);
	}
}
