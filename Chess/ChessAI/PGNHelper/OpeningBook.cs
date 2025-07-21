using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.PGNHelper
{
    public class OpeningBook
    {
        public string Move { get; set; }
        public int Count { get; set; } = 1;
        public double WinRate { get; set; } = 0.0;

        private readonly Dictionary<string, Dictionary<string, int>> book = new();

        //public void AddGame(List<string> moves)
        //{
        //    var state = new GameState();

        //    for (int i = 0; i < moves.Count; i++)
        //    {
        //        string stateKey = new StateString(state.CurrentPlayer, state.Board).ToString();
        //        string nextMove = moves[i];

        //        if (!book.ContainsKey(stateKey))
        //        {
        //            book[stateKey] = new Dictionary<string, int>();
        //        }

        //        if (!book[stateKey].ContainsKey(nextMove))
        //        {
        //            book[stateKey][nextMove] = 0;
        //        }

        //        book[stateKey][nextMove]++;


        //        var move = AlgebraicParser.Parse(nextMove, state);
        //        state.MakeMove(move);
        //    }
        //}

        //public string? GetBestMove(GameState state)
        //{
        //    string key = new StateString(state.CurrentPlayer, state.Board).ToString();
        //    if (book.TryGetValue(key, out var movesDict))
        //    {
        //        return movesDict.OrderByDescending(m => m.Value).FirstOrDefault().Key;
        //    }

        //}
    }
}
