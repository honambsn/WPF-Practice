using Go.Domain.Board;
using Go.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Application.Game
{
    public class GameManager
    {
        public GoBoard Board { get; }
        public StoneColor CurrentTurn { get; private set; } = StoneColor.Black;
        public GameManager()
        {
            Board = new GoBoard();
        }

        public bool PlayMove(int row, int col, out StoneColor playedColor)
        {
            playedColor = CurrentTurn;

            if (!Board.PlaceStone(row, col, CurrentTurn))
            {
                return false;
            }

            CurrentTurn = CurrentTurn == StoneColor.Black
                ? StoneColor.White
                : StoneColor.Black;
            
            return true;
        }

        public void Reset()
        {
            Board.Reset();
            CurrentTurn = StoneColor.Black;
        }

    }
}
