using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.OpeningBook
{
    public class OpeningEntry
    {
        public string StateString { get; set; }
        public string BestMove { get; set; }
        public int Frequency { get; set; } = 1;
        public string FEN { get; set; } = string.Empty;
        public string Move { get; set; } = string.Empty;
    }
}
