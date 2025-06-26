using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.Config
{
    public class BotLevelConfig
    {
        public int Depth { get; set; }
        public bool UseMoveOrdering { get; set; }
        public bool UseTT { get; set; }
        public int TimeLimitMs { get; set; }
    }

}
