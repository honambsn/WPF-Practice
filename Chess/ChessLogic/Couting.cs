using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class Couting
	{
		private readonly Dictionary<PieceType, int> whiteCount = new();
		private readonly Dictionary<PieceType, int> blackCount = new();

		public int TotalCount { get; private set; }
		//public Couting()
		//{
		//	whiteCount[PieceType.Pawn] = 8;
		//	whiteCount[PieceType.Rook] = 2;
		//	whiteCount[PieceType.Knight] = 2;
		//	whiteCount[PieceType.Bishop] = 2;
		//	whiteCount[PieceType.Queen] = 1;
		//	whiteCount[PieceType.King] = 1;

		//	blackCount[PieceType.Pawn] = 8;
		//	blackCount[PieceType.Rook] = 2;
		//	blackCount[PieceType.Knight] = 2;
		//	blackCount[PieceType.Bishop] = 2;
		//	blackCount[PieceType.Queen] = 1;
		//	blackCount[PieceType.King] = 1;
		//}

		public Couting()
		{
			foreach (PieceType type in Enum.GetValues(typeof(PieceType)))
			{
				whiteCount[type] = 0;
				blackCount[type] = 0;
			}
		}

		public void Increment(Player color, PieceType type)
		{
			if (color == Player.White)
			{
				whiteCount[type]++;
			}
			else if (color == Player.Black)
			{
				blackCount[type]++;
			}
			TotalCount++;
		}

		public int White(PieceType type)
		{
			return whiteCount[type];
		}
		public int Black(PieceType type) { return blackCount[type]; }
	}

}
