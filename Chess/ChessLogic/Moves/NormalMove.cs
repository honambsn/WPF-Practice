using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class NormalMove : Move
	{
		public override MoveType Type => MoveType.Normal;
		public override Position FromPos { get; }
		public override Position ToPos { get; }
		private Piece capturedPiece;
		public NormalMove(Position fromPos, Position toPos)
		{
			FromPos = fromPos;
			ToPos = toPos;
		}
		public override bool Execute(Board board)
		{
			Piece piece = board[FromPos];
			capturedPiece = board[ToPos];

			bool capture = !board.IsEmpty(ToPos);
			board[ToPos] = piece;
			board[FromPos] = null;
			piece.HasMoved = true;

			return capture || piece.Type == PieceType.Pawn;
		}

		//public override void Undo(Board board) {
		//	Piece piece = board[ToPos];

		//	board[FromPos] = piece;
		//	board[ToPos] = capturedPiece;
		//	piece.HasMoved = false;
		//}
	}
}
