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

	}
}
