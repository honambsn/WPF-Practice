using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper
{
    #region old ver
    //public static class ZobristHasher
    //{
    //    private static readonly ulong[,,] pieceKeys; // [row, col, pieceIndex]
    //    private static readonly ulong whiteToMoveKey;

    //    static ZobristHasher()
    //    {
    //        Random rng = new(12345); // Fixed seed for reproducibility
    //        pieceKeys = new ulong[8, 8, 12]; // 8 rows, 8 columns, 12 pieces (6 types for each color)

    //        for (int row = 0; row < 8; row++)
    //        {
    //            for (int col = 0; col < 8; col++)
    //            {
    //                for (int i = 0; i < 12; i++)
    //                {
    //                    byte[] buffer = new byte[8];
    //                    rng.NextBytes(buffer);
    //                    pieceKeys[row, col, i] = BitConverter.ToUInt64(buffer, 0);
    //                }
    //            }
    //        }

    //        byte[] moveBuffer = new byte[8];
    //        rng.NextBytes(moveBuffer);
    //        whiteToMoveKey = BitConverter.ToUInt64(moveBuffer, 0);
    //    }

    //    private static int GetPieceIndex(Piece piece)
    //    {
    //        int baseIndex = piece.Type switch
    //        {
    //            PieceType.Pawn => 0,
    //            PieceType.Knight => 1,
    //            PieceType.Bishop => 2,
    //            PieceType.Rook => 3,
    //            PieceType.Queen => 4,
    //            PieceType.King => 5,
    //            _ => throw new ArgumentException("Invalid piece type")
    //        };

    //        return baseIndex + (piece.Color == Player.Black ? 6 : 0); // 6 pieces for each color
    //    }

    //    public static ulong ComputeKey(GameState state)
    //    {
    //        ulong key = 0;

    //        for (int row = 0; row < 8; row++)
    //        {
    //            for (int col = 0; col < 8; col++)
    //            {
    //                var piece = state.Board[row, col];
    //                if (piece != null)
    //                {
    //                    int index = GetPieceIndex(piece);
    //                    key ^= pieceKeys[row, col, index];
    //                }
    //            }
    //        }

    //        if (state.CurrentPlayer == Player.White)
    //        {
    //            key ^= whiteToMoveKey;
    //        }

    //        return key;
    //    }
    //}
    #endregion

    public static class ZobristHasher
    {
        private static readonly ulong[,,] PieceKeys;
        private static readonly ulong SideToMoveKey;
        private static readonly Random rng = new();

        static ZobristHasher()
        {
            PieceKeys = new ulong[6, 2, 64];
            for (int pt = 0; pt < 6; pt++)
            {
                for (int pl = 0; pl < 2; pl++)
                {
                    for (int sq = 0; sq < 64; sq++)
                    {
                        PieceKeys[pt, pl, sq] = RandomUlong();
                    }
                }
                    
            }

            SideToMoveKey = RandomUlong();
        }

        public static ulong ComputeHash(Board board, Player toMove)
        {
            ulong hash = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var piece = board[new Position(row, col)];
                    if (piece != null)
                    {
                        int type = (int)piece.Type;
                        int player = (piece.Color == Player.White) ? 0 : 1;
                        int squareIndex = row * 8 + col;

                        hash ^= PieceKeys[type, player, squareIndex];
                    }
                }
            }

            if (toMove == Player.Black)
            {
                hash ^= SideToMoveKey;
            }

            return hash;
        }

        private static ulong RandomUlong()
        {
            byte[] buffer = new byte[8];
            rng.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }
    }
}
