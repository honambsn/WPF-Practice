using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
					int positional = GetPositionValue(piece.Type, piece.Color, pos);
					int totalValue = value + positional;

					score += (piece.Color == state.CurrentPlayer.Opponent()) ? totalValue : -totalValue;
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

		private int GetPositionValue(PieceType type, Player player, Position pos)
		{
			int row = player == Player.White ? pos.Row : 7 - pos.Row;
			int col = pos.Column;

			switch (type)
			{
				case PieceType.Pawn:
					return row * 10;
				case PieceType.Knight:
				case PieceType.Bishop:
					return (3 - Math.Abs(3 - row)) * 4 + (3 - Math.Abs(3 - col)) * 4 + (row > 0 ? 10: 0);
				case PieceType.Rook:
					return (row == 0 || row == 7) ? 5 : 10;
				case PieceType.Queen:
					return (3 - Math.Abs(3 - row)) * 2 + (3 - Math.Abs(3 - col)) * 2;
				case PieceType.King:
					return row < 2 ? 30 : 0;
				default:
					return 0;

			}

		}
	}
}
