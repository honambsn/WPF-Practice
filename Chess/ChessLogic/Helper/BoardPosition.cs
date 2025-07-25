using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper
{
    public struct BoardPosition : IEquatable<BoardPosition>
    {
        public int File { get; } //  0 = 'a', 1 = 'b', ..., 7 = 'h'
        public int Rank { get; } // 0 = rank 1, 1 = rank 2, ..., 7 = rank 8

        public BoardPosition(int file, int rank)
        {
            if (file < 0 || file > 7 || rank < 0 || rank > 7)
                throw new ArgumentOutOfRangeException(nameof(file), "File must be between 0 and 7.");

            File = file;
            Rank = rank;
        }

        /// <summary>
        /// Converts algebraic notation (e.g., "e4") to a BoardPosition.
        /// </summary>
        /// 
        public static BoardPosition FromAlgebraic(string notation)
        {
            if (notation == null || notation.Length != 2)
                throw new ArgumentException("Invalid algebraic notation.", nameof(notation));

            char fileChar = notation[0];
            char rankChar = notation[1];

            int file  = fileChar - 'a'; // 'a' = 0, 'b' = 1, ..., 'h' = 7
            int rank = rankChar - '1'; // '1' = 0, '2' = 1, ..., '8' = 7

            return new BoardPosition(file, rank);
        }

        /// <summary>
        /// Converts this position to algebraic notation (e.g., "e4").
        /// </summary>
        /// 

        public override string ToString()
        {
            return $"{(char)('a' + File)}{(char)('1' + Rank)}";
        }

        public bool Equals(BoardPosition other)
        {
            return File == other.File && Rank == other.Rank;
        }

        public override bool Equals(object obj)
        {
            return obj is BoardPosition other && Equals(other);
        }

        public override int GetHashCode()
        {
            return File * 8 + Rank;
        }

        public static bool operator ==(BoardPosition a, BoardPosition b) => a.Equals(b);
        public static bool operator !=(BoardPosition a, BoardPosition b) => !a.Equals(b);

    }
}
