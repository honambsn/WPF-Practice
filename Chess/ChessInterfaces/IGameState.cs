using System.Collections.Generic;

namespace ChessInterfaces
{
	public interface IGameState
	{
		bool IsGameOver2();
		IEnumerable<Move> GetAllLegalMoves();
		void ApplyMove(Move move);
		void UndoMove(Move move);
	}
}
