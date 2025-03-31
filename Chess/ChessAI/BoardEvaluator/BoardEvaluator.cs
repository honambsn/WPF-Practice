using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.BoardEvaluator
{
	public class BoardEvaluator
	{
		private readonly Dictionary<PieceType, int> pieceValues = new Dictionary<PieceType, int>()
		{
			{ PieceType.Pawn, 100 },
			{ PieceType.Knight, 320 },
			{ PieceType.Bishop, 330 },
			{ PieceType.Rook, 500 },
			{ PieceType.Queen, 900 },
			{ PieceType.King, 20000 }
		};

		public int Evaluate(GameState state)
		{
			if (state.IsGameOver())
			{
				if (state.Result.Winner == Player.White) return int.MaxValue;
				if (state.Result.Winner == Player.Black) return int.MinValue;
				return 0;
			}
			
			int score = 0;
			
		}

	}
}
