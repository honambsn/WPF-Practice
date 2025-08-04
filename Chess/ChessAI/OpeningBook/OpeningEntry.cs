using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.OpeningBook
{
    public class OpeningEntry
    {
        public ulong ZobristKey { get; set; }
        public List<string> MoveNotations { get; set; } = new();
    }
}
