using Go.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Domain.Board
{
    public class GoBoard
    {
        private readonly StoneColor?[,] board;
        public int Size { get; }
        public GoBoard(int size = 19)
        {
            Size = size;
            board = new StoneColor?[size, size];
        }

        public bool IsOccupied(int row, int col)
        {
            return board[row, col] != null;
        }

        public bool PlaceStone(int row, int col, StoneColor color)
        {
            if (IsOccupied(row, col))
            {
                return false;
            }

            board[row, col] = color;
            return true;
        }

        public StoneColor? GetStone(int row, int col)
        {
            return board[row, col];
        }

        public void Reset()
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    board[r, c] = null;
        }
    }
}
