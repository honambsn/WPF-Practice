using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUI.Utils
{
    public static class MoveFormatter
    {
        public static string Format(Move move, Player player)
        {
            string from = move.FromPos.ToString();
            string to = move.ToPos.ToString();
            string side = player == Player.White ? "White" : "Black";

            return $"{side} : {from} → {to}";
        }
    }
}
