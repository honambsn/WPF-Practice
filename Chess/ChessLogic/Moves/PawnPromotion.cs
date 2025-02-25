﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class PawnPromotion : Move
	{
		public override MoveType Type => MoveType.PawnPromotion;
		public override Position FromPos { get; }
		public override Position ToPos { get; }
		private readonly PieceType newType;
		public PawnPromotion(Position from, Position to, PieceType newType)
		{
			FromPos = from;
			ToPos = to;
			this.newType = newType;
		}

		private Piece CreatePromotionPiece(Player player)
		{
			return newType switch
			{
				PieceType.Queen => new Queen(player),
				PieceType.Rook => new Rook(player),
				PieceType.Bishop => new Bishop(player),
				PieceType.Knight => new Knight(player),
				_ => throw new ArgumentException("Invalid piece type")
			};
		}

		public override void Execute(Board board)
		{
			Piece pawn = board[FromPos];
			board[FromPos] = null;

			Piece promotionPiece = CreatePromotionPiece(pawn.Color);
			promotionPiece.HasMoved = true;
			board[ToPos] = promotionPiece;
		}
	}
}
