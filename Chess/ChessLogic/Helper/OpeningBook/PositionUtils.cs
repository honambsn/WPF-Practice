using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper.OpeningBook
{
    public static class PositionUtils
    {
        public static Position FromAlgebraic(string notation)
        {
            if (string.IsNullOrWhiteSpace(notation) || notation.Length < 2)
                throw new ArgumentException("Invalid algebraic notation.", nameof(notation));

            char file = notation[0];
            if (file < 'a' || file > 'h')
                throw new ArgumentOutOfRangeException(nameof(notation), "File must be between 'a' and 'h'.");

            if (!int.TryParse(notation.Substring(1), out int rank))
                throw new ArgumentException("Invalid rank in algebraic notation.", nameof(notation));

            // rank 1 -> row 7,  rank 8 -> row 0
            int row = 8 - rank;
            int column = file - 'a'; // 'a' = 0, 'b' = 1, ..., 'h' = 7

            return new Position(row, column);
        }

        public static string ToAlgebraic(Position pos)
        {
            char file = (char)('a' + pos.Column); // 'a' = 0, 'b' = 1, ..., 'h' = 7
            int rank = 8 - pos.Row; // row 0 -> rank 8, row 7 -> rank 1
            return $"{file}{rank}";
        }
    }
}
