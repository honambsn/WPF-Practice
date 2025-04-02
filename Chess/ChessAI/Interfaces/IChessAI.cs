using ChessAI.Config;
using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.Interfaces
{
	public interface IChessAI
	{
		Move? GetBestMove(GameState gameState);
		IEnumerable<Move> GetBestMoves(GameState gameState);
		void SetDifficulty(BotDifficulty difficulty);
		(Move? BestMove, int Evaluation) GetDetailedMove(GameState gameState);
	}
}
