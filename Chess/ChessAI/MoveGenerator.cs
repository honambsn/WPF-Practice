using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;
using System.Collections.Generic;

namespace ChessAI
{
	public static class MoveGenerator
	{
		public static IEnumerable<Move> Generate(GameState state)
		{
			return state.GetAllLegalMoves();
		}

		public static List<Move> GenerateCaptureMoves(GameState state)
		{
			var allMoves = Generate(state); 
			return allMoves.Where(m => state.Board[m.ToPos] != null).ToList();
		}

		public static IEnumerable<Move> GenerateForPlayer(GameState state, Player player)
		{
			//return state.GetAllLegalMoves().Where(m => state.Board[m.FromPos].Color == player);
			return Generate(state).Where(m => state.Board[m.FromPos].Color == player); // Filter moves for the specified player
		}

	}
}
