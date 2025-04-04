using ChessLogic; // To access GameState, Move, BotDifficulty, etc.
using ChessInterfaces; // If needed, for any other interfaces like IMove
using System.Collections.Generic;

namespace ChessInterfaces
{
	public interface IChessAI
	{
		// Get the best move for the current game state
		Move? GetBestMove(IGameState gameState);

		// Get all best moves for the current game state
		IEnumerable<Move> GetBestMoves(IGameState gameState);

		// Set the AI's difficulty level
		void SetDifficulty(BotDifficulty difficulty);

		// Get the best move along with its evaluation score
		(Move? BestMove, int Evaluation) GetDetailedMove(IGameState gameState);
	}
}
