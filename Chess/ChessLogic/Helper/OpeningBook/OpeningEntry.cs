using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper.OpeningBook
{
    public class OpeningEntry
    {
        public string StateString { get; set; }
        public string BestMove { get; set; }
        public int Frequency { get; set; } = 1;
        public string FEN { get; set; } = string.Empty;
        public string Move { get; set; } = string.Empty;
        public Move Movee { get; set; }

        public string MoveNotation { get; set; }

        public List<string> MoveNotations { get; set; } = new List<string>();

        public string FirstMove => MoveNotations.FirstOrDefault();

        public OpeningEntry(List<string> moves)
        {
            MoveNotations = new List<string>(moves);
            Frequency = 1;
        }

        public override bool Equals(object obj)
        {
            return obj is OpeningEntry entry &&
                MoveNotations.SequenceEqual(entry.MoveNotations);
        }

        public override int GetHashCode()
        {
            return string.Join(",", MoveNotations).GetHashCode();
        }

        //public OpeningEntry(string notation, int frequency)
        //{
        //    MoveNotation = notation;
        //    Frequency = frequency;
        //}

        public OpeningEntry(Move move)
        {
            Movee = move;
            Frequency = 1;
        }
    }
}
