﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class DoublePawn: Move
	{
		public override MoveType Type => MoveType.DoublePawn;
		public override Position FromPos { get; }
		public override Position ToPos { get; }
		public readonly Position skippedPos;
		public DoublePawn(Position fromPos, Position toPos)
		{
			FromPos = fromPos;
			ToPos = toPos;
			skippedPos = new Position((fromPos.Row + toPos.Row) / 2, fromPos.Column);
		}

		public override bool Execute(Board board)
		{
			Player player = board[FromPos].Color;
			board.SetPawnSkipPosition(player, skippedPos);
			new NormalMove(FromPos, ToPos).Execute(board);
			
			return true;
		}
	}
}
