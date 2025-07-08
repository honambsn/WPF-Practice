using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public static class Zobrist
    {
        public static ulong[,,] PieceSquareKeys; // [color, pieceType, square]
        public static ulong SideToMoveKey; // Key for side to move

        // [0..3] KQkq
        public static ulong[] CastlingKeys; // [0..3] for castling rights (0: no rights, 1: white kingside, 2: white queenside, 3: black kingside, 4: black queenside)

        public static ulong[] EnPassantKeys; // Key for en passant square 8 files

        static Zobrist()
        {
            Random rng = new Random(123456); // or use a fixed seed for reproducibility

            PieceSquareKeys = new ulong[2, 6, 64]; // 2 colors, 6 piece types, 64 squares

            for (int color = 0; color < 2; color++)
            {
                for (int pieceType = 0; pieceType < 6; pieceType++)
                {
                    for (int square = 0; square < 64; square++)
                    {
                        PieceSquareKeys[color, pieceType, square] = (ulong)rng.Next() ^ ((ulong)rng.Next() << 32);
                    }
                }
            }
            SideToMoveKey = RandomUlong(rng);

            CastlingKeys = new ulong[4]; // KQkq

            for (int i = 0; i < 4; i++)
            {
                CastlingKeys[i] = RandomUlong(rng);
            }

            EnPassantKeys = new ulong[8]; // a-h
            for (int i = 0; i < 8; i++)
            {
                EnPassantKeys[i] = RandomUlong(rng);
            }
        }

        private static ulong RandomUlong(Random rng)
        {
            //return (ulong)rng.Next() ^ ((ulong)rng.Next() << 32);
            byte[] buffer = new byte[8];
            rng.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }
    }
}
