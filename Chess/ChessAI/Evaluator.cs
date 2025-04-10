using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;

namespace ChessAI
{
	public class Evaluator
	{
		public int EvaluateBoard(GameState state)
		{
			int score = 0;

			foreach (var player in new[] { Player.White, Player.Black })
			{
				var positions = state.Board.PiecePositionsFor(player);

				foreach (var pos in positions)
				{
					var piece = state.Board[pos];
					int value = GetPieceValue(piece.Type);

					score += (piece.Color == state.CurrentPlayer.Opponent()) ? value : -value;
				}
			}

			return score;
		}

		private int GetPieceValue(PieceType type)
		{
			return type switch
			{
				PieceType.Pawn => 100,
				PieceType.Knight => 320,
				PieceType.Bishop => 330,
				PieceType.Rook => 500,
				PieceType.Queen => 900,
				PieceType.King => 20000,
				_ => 0
			};
		}
	}
}
