using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class Board
	{
		private readonly Piece[,] pieces = new Piece[8, 8];

		private readonly Dictionary<Player, Position> pawnSkipPostions = new Dictionary<Player, Position>
		{
			{ Player.White, null },
			{ Player.Black, null }
		};

		public Piece this[int row, int col]
		{
			get => pieces[row, col];
			set => pieces[row, col] = value;
		}

		public Piece this[Position pos]
		{
			get => this[pos.Row, pos.Column];
			set => this[pos.Row, pos.Column] = value;
		}

		public Position GetPawnSkipPosition(Player player)
		{
			return pawnSkipPostions[player];
		}

		public void SetPawnSkipPosition(Player player, Position pos)
		{
			pawnSkipPostions[player] = pos;
		}

		public static Board Initial()
		{
			Board board = new Board();
			board.AddStartPieces();
			return board;
		}

		private void AddStartPieces()
		{
			this[0, 0] = new Rook(Player.Black);
			this[0, 1] = new Knight(Player.Black);
			this[0, 2] = new Bishop(Player.Black);
			this[0, 3] = new Queen(Player.Black);
			this[0, 4] = new King(Player.Black);
			this[0, 5] = new Bishop(Player.Black);
			this[0, 6] = new Knight(Player.Black);
			this[0, 7] = new Rook(Player.Black);

			this[7, 0] = new Rook(Player.White);
			this[7, 1] = new Knight(Player.White);
			this[7, 2] = new Bishop(Player.White);
			this[7, 3] = new Queen(Player.White);
			this[7, 4] = new King(Player.White);
			this[7, 5] = new Bishop(Player.White);
			this[7, 6] = new Knight(Player.White);
			this[7, 7] = new Rook(Player.White);

			for (int c = 0; c < 8; c++)
			{
				this[1, c] = new Pawn(Player.Black);
				this[6, c] = new Pawn(Player.White);
			}
		}

		public static bool IsInside(Position pos)
		{
			return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
		}

		public bool IsEmpty(Position pos)
		{
			return this[pos] == null;
		}

		public IEnumerable<Position> PiecePositions()
		{
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					Position pos = new Position(r, c);

					if (!IsEmpty(pos))
					{
						yield return pos;
					}
				}
			}
		}

		public IEnumerable<Position> PiecePositionsFor(Player player)
		{
			return PiecePositions().Where(pos => this[pos].Color == player);
		}

		public bool IsInCheck(Player player)
		{
			return PiecePositionsFor(player.Opponent()).Any(pos =>
			{
				Piece piece = this[pos];
				return piece.CanCaptureOpponentKing(pos, this);
			});
		}

		public Board Copy()
		{
			Board copy = new Board();
			foreach (Position pos in PiecePositions())
			{
				copy[pos] = this[pos].Copy();
			}

			return copy;
		}

		public Couting CountPieces()
		{
			Couting couting = new Couting();
			foreach (Position pos in PiecePositions())
			{
				Piece piece = this[pos];
				couting.Increment(piece.Color, piece.Type);
			}
			return couting;
		}

		public bool InsufficientMaterial()
		{
			Couting couting = CountPieces();

			return IsKingVKing(couting) || IsKingBishopVKing(couting) ||
				IsKingKnightVKing(couting) || IsKingBishopVKingBishop(couting);
		}

		private static bool IsKingVKing(Couting couting)
		{
			return couting.TotalCount == 2;
		}


		private static bool IsKingBishopVKing(Couting couting)
		{
			//return couting.TotalCount == 3 &&
			//	couting.White(PieceType.Bishop) == 1 &&
			//	couting.Black(PieceType.Bishop) == 1;
			return couting.TotalCount == 3 &&
		  (couting.White(PieceType.Bishop) == 1 && couting.Black(PieceType.King) == 1) ||
		  (couting.Black(PieceType.Bishop) == 1 && couting.White(PieceType.King) == 1);
		}


		private static bool IsKingKnightVKing(Couting couting)
		{
			return couting.TotalCount == 3 && (couting.White(PieceType.Knight) == 1 && couting.Black(PieceType.Knight) == 1);
		}

		private bool IsKingBishopVKingBishop(Couting couting)
		{
			if (couting.TotalCount != 4)
			{
				return false;
			}
			if (couting.White(PieceType.Bishop) != 1 || couting.Black(PieceType.Bishop) != 1)
			{
				return false;
			}
			//Position wBishopPos = FindPiece(Player.White, PieceType.Bishop);
			//Position bBishopPos = FindPiece(Player.Black, PieceType.Bishop);

			//return wBishopPos.SquareColor() == bBishopPos.SquareColor();
			return true;
		}

		private Position FindPiece(Player color, PieceType type)
		{
			return PiecePositionsFor(color).First(pos => this[pos].Type == type);
		}
	}
}
