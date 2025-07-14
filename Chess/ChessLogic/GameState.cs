using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class GameState
	{
		public Board Board { get; }
		public Player CurrentPlayer { get; private set; }
		public Result Result { get; private set; } = null;
		private int noCaptureOrPawnMoves = 0;
		private string stateString;
		private readonly Dictionary<string, int> stateHistory = new Dictionary<string, int>();
		public Move LastMove { get; private set; }
		public Position? CheckedKingPosition { get; private set; } = null;

        public GameState(Player player, Board board)
		{
			CurrentPlayer = player;
			Board = board;

			stateString = new StateString(CurrentPlayer, board).ToString();
			stateHistory[stateString] = 1;
		}

		public IEnumerable<Move> LegalMovesForPiece(Position pos)
		{
			if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
			{
				return Enumerable.Empty<Move>();
			}

			Piece piece = Board[pos];
			IEnumerable<Move> moveCandiates = piece.GetMoves(pos, Board);
			return moveCandiates.Where(move => move.IsLegal(Board));
		}

		public void MakeMove(Move move)
		{
			Board.SetPawnSkipPosition(CurrentPlayer, null);
			bool captureOrPawn = move.Execute(Board);

			LastMove = move;

			if (captureOrPawn)
			{
				noCaptureOrPawnMoves = 0;
				stateHistory.Clear();
			}
			else
			{
				noCaptureOrPawnMoves++;
			}

			Player opponent = CurrentPlayer.Opponent();
			CheckedKingPosition = Board.GetCheckedKingPosition(opponent);
			if (CheckedKingPosition != null)
			{
				// Log the check state for debugging
				Debug.WriteLine($"From gamestate debugging");

                Debug.WriteLine($"King of {opponent} is checked at {CheckedKingPosition}");
				Debug.WriteLine($"Postion: row: { CheckedKingPosition.Row}  and col: {CheckedKingPosition.Column}");
            }
			else
			{
                Debug.WriteLine($"From gamestate debugging");
                Debug.WriteLine($"king not checked");
			}
			
            CurrentPlayer = CurrentPlayer.Opponent();
			UpdateStateString();
			CheckForGameOver();
		}

		public IEnumerable<Move> AllLegalMovesFor(Player player)
		{
			IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player)
				.SelectMany(pos =>
				{
					Piece piece = Board[pos];
					return piece.GetMoves(pos, Board);
				});

			return moveCandidates.Where(move => move.IsLegal(Board));
		}

		private void CheckForGameOver()
		{
			if (!AllLegalMovesFor(CurrentPlayer).Any())
			{
				if (Board.IsInCheck(CurrentPlayer))
				{
					Result = Result.Win(CurrentPlayer.Opponent());
				}
				else
				{
					Result = Result.Draw(EndReason.Stalemate);
				}
			}

			else if (Board.InsufficientMaterial())
			{
				Result = Result.Draw(EndReason.InsufficientMaterial);
			}

			else if (FiftyMoveRule())
			{
				Result = Result.Draw(EndReason.FiftyMoveRule);

			}
			else if (ThreefoldRepetition())
			{
				Result = Result.Draw(EndReason.ThreefoldRepetition);
			}
		}

		public bool IsGameOver()
		{
			return Result != null;
		}

		private bool FiftyMoveRule()
		{
			//return noCaptureOrPawnMoves >= 100;

			int fullMoves = noCaptureOrPawnMoves / 2;
			// important to check for full moves(both side move = 1 move), not half moves
			return fullMoves == 50;
		}

		private void UpdateStateString()
		{
			stateString = new StateString(CurrentPlayer, Board).ToString();

			if (!stateHistory.ContainsKey(stateString))
			{
				stateHistory[stateString] = 1;
			}
			else
			{
				stateHistory[stateString]++;
			}
		}

		private bool ThreefoldRepetition()
		{
			return stateHistory[stateString] == 3;
		}

		// for ai
		private Stack<MoveInfo> _moveHistory = new Stack<MoveInfo>();

		public void ApplyMove(Move move)
		{
			var fromPiece = Board[move.FromPos];
			var toPiece = Board[move.ToPos];
			var captured = toPiece;

			// Xử lý phong hậu (nếu có)
			Piece promoted = null;
			if (fromPiece.Type == PieceType.Pawn &&
			   ((fromPiece.Color == Player.White && move.ToPos.Row == 0) ||
				(fromPiece.Color == Player.Black && move.ToPos.Row == 7)))
			{
				promoted = new Queen(fromPiece.Color);
				Board[move.ToPos] = promoted;
				Board[move.FromPos] = null;
			}
			else
			{
				Board[move.ToPos] = fromPiece;
				Board[move.FromPos] = null;
			}

			//_moveHistory.Push(new MoveInfo(move, captured, promoted, CurrentPlayer));

			LastMove = move;
			_moveHistory.Push(new MoveInfo(move, captured, promoted, CurrentPlayer));

			// Đổi lượt
			CurrentPlayer = CurrentPlayer == Player.White ? Player.Black : Player.White;
		}

		public void UndoMove()
		{
			if (_moveHistory.Count == 0) return;

			var info = _moveHistory.Pop();
			var move = info.Move;

			// Hoàn tác di chuyển
			if (info.Promoted != null)
			{
				Board[move.FromPos] = new Pawn(info.Promoted.Color);
			}
			else
			{
				Board[move.FromPos] = Board[move.ToPos];
			}

			Board[move.ToPos] = info.Captured;

			// Hoàn tác lượt
			CurrentPlayer = info.PreviousPlayer;
		}

		// Thông tin để hoàn tác nước đi
		private record MoveInfo(Move Move, Piece Captured, Piece Promoted, Player PreviousPlayer);


		public IEnumerable<Move> GetAllLegalMoves()
		{
			return AllLegalMovesFor(CurrentPlayer);
		}

		public GameState Copy()
		{
			var copy = new GameState(this.CurrentPlayer, this.Board.Copy());
			copy.Result = this.Result;
			return copy;
		}

		public bool IsGameOver2() => Result != null;


		public ulong ZobristKey => ComputeZobristKey();

		private ulong ComputeZobristKey()
		{
			ulong key = 0;

			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					Piece? piece = Board[row, col];
					if (piece != null)
					{
						int colorIndex = (piece.Color == Player.White) ? 0 : 1;
						int pieceIndex = piece.Type switch
						{
							PieceType.Pawn => 0,
							PieceType.Knight => 1,
							PieceType.Bishop => 2,
							PieceType.Rook => 3,
							PieceType.Queen => 4,
							PieceType.King => 5,
							_ => 0
						};
                        
						int square = row * 8 + col;
                        key ^= Zobrist.PieceSquareKeys[colorIndex, pieceIndex, square];
                    }
					
                    //Position pos = new Position(row, col);
                    //if (Board.IsEmpty(pos)) continue;

                    //Piece piece = Board[pos];
                    //int pieceIndex = (int)piece.Type + (piece.Color == Player.White ? 0 : 6);
                    //key ^= ZobristTable.GetZobristHash(pos, pieceIndex);
                }
			}

			// side to move
			if (CurrentPlayer == Player.Black)
			{
				key ^= Zobrist.SideToMoveKey;
			}

			// Castling rights

			if (Board.CastleRightKS(Player.White))
            {
                key ^= Zobrist.CastlingKeys[0]; // White kingside
            }
			if (Board.CastleLeftQS(Player.White))
            {
                key ^= Zobrist.CastlingKeys[1]; // White queenside
            }
            if (Board.CastleRightKS(Player.Black))
            {
                key ^= Zobrist.CastlingKeys[2]; // Black kingside
            }
            if (Board.CastleLeftQS(Player.Black))
            {
                key ^= Zobrist.CastlingKeys[3]; // Black queenside
            }

			// en passant
			if (Board.CanCaptureEnPassant(CurrentPlayer))
			{
				Position skip = Board.GetPawnSkipPosition(CurrentPlayer.Opponent());
				key ^= Zobrist.EnPassantKeys[skip.Column];
            }

			return key;
        }
	}
}
