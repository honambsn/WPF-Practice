using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using ChessLogic.Helper.PGN;
using System.Xml;


namespace ChessLogic.Helper.OpeningBook
{
    #region old version
    //public class BuildOpeningBook
    //{
    //    private Dictionary<string, Dictionary<string, int>> openingBook = new();

    //    public void BuildFromPGN(string pgnFilePath)
    //    {
    //        if (!File.Exists(pgnFilePath))
    //        {
    //            Debug.WriteLine(pgnFilePath + " does not exist. Please provide a valid PGN file path.");
    //            return;
    //        }

    //        var games = PGNReader.ReadGamesFromPGN(pgnFilePath);
    //        Debug.WriteLine("Number of games read: " + games.Count);
    //        Debug.WriteLine(games.Count + " games read from PGN file.");

    //        foreach (var moveList in games)
    //        {
    //            AddGameToBook(moveList);
    //        }

    //        Debug.WriteLine($"Opening book built with {openingBook.Count} unique positions.");
    //    }

    //    private void AddGameToBook(List<string> moveNotations)
    //    {
    //        var state = new GameState(Player.White, Board.Initial());
    //        var sequence = new List<string>();

    //        foreach (var notation in moveNotations)
    //        {
    //            var move = AlgebraicNotationHelper.ToAlgebraicNotation(notation, state);

    //            if (move == null) break;

    //            string key = string.Join(" ", sequence);
    //            string moveKey = move.ToString();

    //            if (!openingBook.ContainsKey(key))
    //            {
    //                openingBook[key] = new Dictionary<string, int>();
    //            }

    //            if (!openingBook[key].ContainsKey(moveKey))
    //            {
    //                openingBook[key][moveKey] = 0;
    //            }

    //            openingBook[key][moveKey]++;

    //            state.ApplyMove(move);
    //            sequence.Add(moveKey);
    //        }
    //    }

    //    public void SaveToFile(string outputPath)
    //    {
    //        var json = JsonSerializer.Serialize(openingBook, new JsonSerializerOptions { WriteIndented = true });

    //        File.WriteAllText(outputPath, json);
    //        Debug.WriteLine("Opening book saved to " + outputPath);
    //    }

    //    public static void GenerateBook(string pgnFile, string outputFile)
    //    {
    //        var games = PGNReader.ReadPGN(pgnFile);
    //        var book = new Dictionary<ulong, Dictionary<Move, int>>();

    //        foreach (var game in games)
    //        {
    //            var state = new GameState(Player.White, Board.Initial());

    //            foreach (var notation in game.MoveNotations)
    //            {
    //                try
    //                {
    //                    var move = AlgebraicNotationHelper.FromAlgebraic(notation, state);
    //                    var hash = state.ZobristKey;

    //                    if (!book.ContainsKey(hash))
    //                        book[hash] = new();

    //                    if (!book[hash].ContainsKey(move))
    //                        book[hash][move] = 0;

    //                    book[hash][move]++;
    //                    state.ApplyMove(move);
    //                }
    //                catch (Exception ex)
    //                {
    //                    Debug.WriteLine($"Error processing move '{notation}': {ex.Message}");
    //                    //continue;
    //                    break;
    //                }

    //            }
    //        }

    //        OpeningBookFormat.Save(book, outputFile);
    //    }

    //}
    #endregion

    #region version 1.1
    //public static class BuildOpeningBook
    //{
    //    public static void BuildFromPGN(string pgnPath, string outputPath)
    //    {
    //        var allGames = PGNReader.ReadGamesFromPGN(pgnPath);
    //        var book = new Dictionary<string, OpeningEntry>();

    //        foreach (var moves in allGames)
    //        {
    //            var sequence = new List<string>();

    //            foreach (var notation in moves)
    //            {
    //                sequence.Add(notation);
    //                string key = string.Join(" ", sequence);

    //                if (!book.ContainsKey(key))
    //                {
    //                    book[key] = new OpeningEntry(sequence);
    //                }
    //                else
    //                    book[key].Frequency++;
    //            }
    //        }

    //        string json = JsonSerializer.Serialize(book.Values, new JsonSerializerOptions { WriteIndented = true });
    //        File.WriteAllText(outputPath, json);
    //    }
    //}
    #endregion

    #region version 1.2
    //public class BuildOpeningBook
    //{
    //    public static void Build(string pgnFile, string outputFile)
    //    {
    //        var lines = File.ReadAllLines(pgnFile);
    //        Dictionary<ulong, List<OpeningEntry>> book = new();

    //        GameState state = new(Player.White, Board.Initial());
    //        ZobristHasing zobrist = new();

    //        foreach (var line lines)
    //        {
    //            if (line.StartsWith("[")) continue;

    //            var tokens = line.Split(' ');
    //            state = new GameState(Player.White, Board.Initial());

    //            foreach (var token in tokens)
    //            {
    //                if (string.IsNullOrWhiteSpace(token) || token.Contains(".") || token == "1-0" || token == "0-1" || token == "1/2-1/2")
    //                    continue;

    //                var move = AlgebraicNotationHelper.ParseMove(token, state);
    //                ulong key = zobrist.ComputeHash(state);

    //                if (!book.ContainsKey(key))
    //                {
    //                    book[key] = new();
    //                }

    //                var entry = book[key].FirstOrDefault(e => e.Move.Equals(move));
    //                if (entry == null)
    //                    book[key].Add(new OpeningEntry(move));
    //                else
    //                    entry.Frequency++;

    //                state.ApplyMove(move);
    //            }
    //        }

    //        File.WriteAllText(outputFile, JsonConvert.SerializeObject(book, Formatting.Indented));

    //    }
    //}
    #endregion

    public static class BuildOpeningBook
    {
        public static void Build(string pgnFile, string outputPath)
        {
            var allLines = File.ReadAllLines(pgnFile)
                                .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("["))
                                .ToList();

            //List<string> allMoves = PGNReader.ReadMovesFromPGN(allLines);
            //Dictionary<ulong, HashSet<string>> openingMap = new();
        }
    }
}
