using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class StateString
	{
		private readonly StringBuilder sb = new StringBuilder();
		public StateString(Player currentPlayer, Board board)
		{
			AddPiecePlacement(board);
			sb.Append(' ');
			AddCurrentPlayer(currentPlayer);
			sb.Append(' ');
			AddCastlingRights(board);
			sb.Append(' ');
			AddEnPassent(board, currentPlayer);
		}

		public override string ToString()
		{
			return sb.ToString();
		}

		private static char PieceChar(Piece piece)
		{
			char c = piece.Type switch
			{
				PieceType.Pawn => 'P',
				PieceType.Knight => 'n',
				PieceType.Rook => 'r',
				PieceType.Bishop => 'b',
				PieceType.Queen => 'q',
				PieceType.King => 'k',
				_ => ' '
			};

			if (piece.Color == Player.White)
			{
				return char.ToUpper(c);
			}

			return c;
		}

		private void AddRowData(Board board, int row)
		{
			int empty = 0;
			for (int col = 0; col < 8; col++)
			{
				if (board[row, col] == null)
				{
					empty++;
					continue;
				}
				if (empty > 0)
				{
					sb.Append(empty);
					empty = 0;
				}
				sb.Append(PieceChar(board[row, col]));
			}

			if (empty > 0)
			{
				sb.Append(empty);
			}
		}

		private void AddPiecePlacement(Board board)
		{
			for (int r = 0; r < 8; r++)
			{
				if (r != 0)
				{
					sb.Append('/');
				}

				AddRowData(board, r);
			}
		}

		private void AddCurrentPlayer(Player currentPlayer)
		{
			if (currentPlayer == Player.White)
			{
				sb.Append('w');
			}
			else
			{
				sb.Append('b');
			}
		}

		private void AddCastlingRights(Board board)
		{
			bool castleWKS = board.CastleRightKS(Player.White);
			bool castleWQS = board.CastleLeftQS(Player.White);

			bool castleBKS = board.CastleRightKS(Player.Black);
			bool castleBQS = board.CastleLeftQS(Player.Black);

			if (!(castleWKS || castleWQS || castleBKS || castleBQS))
			{
				sb.Append('-');
				return;
			}

			if (castleWKS)
			{
				sb.Append('K');
			}

			if (castleWQS)
			{
				sb.Append('Q');
			}

			if (castleBKS)
			{
				sb.Append('k');
			}

			if (castleBQS)
			{
				sb.Append('q');
			}
		}

		private void AddEnPassent(Board board, Player currentplayer)
		{
			if (!board.CanCaptureEnPassant(currentplayer))
			{
				sb.Append('-');
				return;
			}

			Position pos = board.GetPawnSkipPosition(currentplayer.Opponent());
			char file = (char)('a' + pos.Column);
			int rank = 8 - pos.Row;
			sb.Append(file);
			sb.Append(rank);

		}
	}

	public static class StateHelper
	{
		public static string GetPieceSymbol(Piece piece)
		{
			if (piece == null)
			{
				return "?";
            }

			string symbol = piece.Type switch
            {
                PieceType.Pawn => "P",
                PieceType.Knight => "N",
                PieceType.Rook => "R",
                PieceType.Bishop => "B",
                PieceType.Queen => "Q",
                PieceType.King => "K",
                _ => "?"
            };

			return symbol;
        }
	}
}
