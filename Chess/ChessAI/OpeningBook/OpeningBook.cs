using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography;
using ChessLogic.Helper.OpeningBook;


#region old version
//namespace ChessAI.OpeningBook
//{
//    public class OpeningBook
//    {
//        public string Move { get; set; }
//        public int Count { get; set; } = 1;
//        public double WinRate { get; set; } = 0.0;

//        //private readonly Dictionary<string, Dictionary<string, int>> book = new();
//        //private readonly Dictionary<string, Move> book = new();
//        private Dictionary<string, List<OpeningEntry>> book = new();
//        private Dictionary<string, List<string>> _book = new();

//        public void AddEntry(OpeningEntry entry)
//        {
//            if (!_book.ContainsKey(entry.FEN))
//                _book[entry.FEN] = new List<string>();

//            if (!_book[entry.FEN].Contains(entry.Move))
//                _book[entry.FEN].Add(entry.Move);
//        }

//        public List<string>? GetMoves(string fen)
//        {
//            return _book.TryGetValue(fen, out var moves) ? moves : null;
//        }


//        public void LoadFromJson(string path)
//        {
//            var json = File.ReadAllText(path);
//            _book = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json) ?? new Dictionary<string, List<string>>();
//        }

//        public void SaveToJson(string path)
//        {
//            var json = JsonSerializer.Serialize(_book, new JsonSerializerOptions { WriteIndented = true });
//            File.WriteAllText(path, json);
//        }

//        //public void Add(string stateString, string move)
//        //{
//        //    if (!book.ContainsKey(stateString))
//        //    {
//        //        book[stateString] = new List<OpeningEntry>();
//        //    }

//        //    var existing = book[stateString].FirstOrDefault(e => e.BestMove == move);

//        //    if (existing != null) existing.Frequency++;
//        //    else book[stateString].Add(new OpeningEntry
//        //    {
//        //        StateString = stateString,
//        //        BestMove = move,
//        //        Frequency = 1
//        //    });
//        //}

//        public string GetBestMove(string stateString)
//        {
//            if (!book.ContainsKey(stateString)) return null;

//            return book[stateString].OrderByDescending(e => e.Frequency).First().BestMove;
//        }

//        public void Save(string filePath)
//        {
//            File.WriteAllText(filePath, System.Text.Json.JsonSerializer.Serialize(book));
//        }

//        public void Load(string filePath)
//        {
//            if (File.Exists(filePath))
//                book = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<OpeningEntry>>>(File.ReadAllText(filePath)) ?? new Dictionary<string, List<OpeningEntry>>();
//        }
//        //public void AddGame(List<string> moves)
//        //{
//        //    var state = new GameState();

//        //    for (int i = 0; i < moves.Count; i++)
//        //    {
//        //        string stateKey = new StateString(state.CurrentPlayer, state.Board).ToString();
//        //        string nextMove = moves[i];

//        //        if (!book.ContainsKey(stateKey))
//        //        {
//        //            book[stateKey] = new Dictionary<string, int>();
//        //        }

//        //        if (!book[stateKey].ContainsKey(nextMove))
//        //        {
//        //            book[stateKey][nextMove] = 0;
//        //        }

//        //        book[stateKey][nextMove]++;


//        //        var move = AlgebraicParser.Parse(nextMove, state);
//        //        state.MakeMove(move);
//        //    }
//        //}

//        //public string? GetBestMove(GameState state)
//        //{
//        //    string key = new StateString(state.CurrentPlayer, state.Board).ToString();
//        //    if (book.TryGetValue(key, out var movesDict))
//        //    {
//        //        return movesDict.OrderByDescending(m => m.Value).FirstOrDefault().Key;
//        //    }

//        //}
//    }
//}


//namespace ChessAI.OpeningBook
//{
//    public class OpeningBook
//    {
//        private Dictionary<ulong, List<OpeningEntry>> _entries;

//        public OpeningBook(string filePath)
//        {
//            _entries = OpeningBookFormat.Load(filePath);
//        }

//        public Move? GetBestMove(GameState state)
//        {
//            var hash = state.ZobristKey;
//            if (!_entries.ContainsKey(hash))
//            {
//                return null; // No entry for this position
//            }

//            var list  = _entries[hash];
//            var bestNotation = list.OrderByDescending(e => e.Frequency).FirstOrDefault()?.MoveNotation;


//            try
//            {
//                return AlgebraicNotationHelper.FromAlgebraic(bestNotation, state);
//            }
//            catch
//            {
//                return null; // Invalid move notation
//            }
//        }

//    }
//}

#endregion

namespace ChessAI.OpeningBook
{
    public class OpeningBook
    {
        private Dictionary<string, List<string>> book = new();

        public OpeningBook(string jsonPath)
        {
            var entries = JsonSerializer.Deserialize<List<OpeningEntry>>(File.ReadAllText(jsonPath));

            foreach (var entry in entries)
            {
                string key = string.Join(" ", entry.MoveNotations.Take(entry.MoveNotations.Count - 1));
                string nextMove = entry.MoveNotations.Last();

                if (!book.ContainsKey(key))
                    book[key] = new List<string>();

                book[key].Add(nextMove);
            }
        }
        public string? GetNextMove(List<string> playedMoves)
        {
            string key = string.Join(" ", playedMoves);

            if (!book.ContainsKey(key)) return null;

            var possible = book[key];
            Random rng = new Random();

            return possible[rng.Next(possible.Count)];
        }
    }

    public class OpeningEntry
    {
        public List<string> MoveNotations { get; set; } = new();
        public int Frequency { get; set; }
    }
}