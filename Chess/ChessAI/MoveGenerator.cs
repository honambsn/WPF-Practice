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
	}
}
