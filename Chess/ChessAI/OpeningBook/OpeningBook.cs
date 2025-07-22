using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ChessAI.OpeningBook;
namespace ChessLogic.OpeningBook
{
    public class OpeningBook
    {
        public string Move { get; set; }
        public int Count { get; set; } = 1;
        public double WinRate { get; set; } = 0.0;

        //private readonly Dictionary<string, Dictionary<string, int>> book = new();
        //private readonly Dictionary<string, Move> book = new();
        private Dictionary<string, List<OpeningEntry>> book = new();

        public void Add(string stateString, string move)
        {
            if (!book.ContainsKey(stateString))
            {
                book[stateString] = new List<OpeningEntry>();
            }

            var existing = book[stateString].FirstOrDefault(e => e.BestMove == move);

            if (existing != null) existing.Frequency++;
            else book[stateString].Add(new OpeningEntry
            {
                StateString = stateString,
                BestMove = move,
                Frequency = 1
            });
        }

        public string GetBestMove(string stateString)
        {
            if (!book.ContainsKey(stateString)) return null;

            return book[stateString].OrderByDescending(e => e.Frequency).First().BestMove;
        }

        public void Save(string filePath)
        {
            File.WriteAllText(filePath, System.Text.Json.JsonSerializer.Serialize(book));
        }

        public void Load(string filePath)
        {
            if (File.Exists(filePath))
                book = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<OpeningEntry>>>(File.ReadAllText(filePath)) ?? new Dictionary<string, List<OpeningEntry>>();
        }
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
