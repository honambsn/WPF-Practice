using ChessAI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic.Helper;
using ChessLogic;
using System.Diagnostics;
using System.Text.Json;


namespace ChessLogic.OpeningBook
{
    public class BuildOpeningBook
    {
        private Dictionary<string, Dictionary<string, int>> openingBook = new();

        public void BuildFromPGN(string pgnFilePath)
        {
            if (!File.Exists(pgnFilePath))
            {
                Debug.WriteLine(pgnFilePath + " does not exist. Please provide a valid PGN file path.");
                return;
            }

            var games = PGNReader.ReadGamesFromPGN(pgnFilePath);
            Debug.WriteLine("Number of games read: " + games.Count);
            Debug.WriteLine(games.Count + " games read from PGN file.");

            foreach(var moveList in games)
            {
                AddGameToBook(moveList);
            }

            Debug.WriteLine($"Opening book built with {openingBook.Count} unique positions.");
        }

        private void AddGameToBook(List<string> moveNotations)
        {
            var state = new GameState();
            var sequence = new List<string>();

            foreach(var notation in moveNotations)
            {
                var move = AlgebraicNotationHelper.ToAlgebraicNotation(notation, state);

                if (move == null) break;

                string key = string.Join(" ", sequence);
                string moveKey = move.ToString();

                if (!openingBook.ContainsKey(key))
                {
                    openingBook[key] = new Dictionary<string, int>();
                }

                if (!openingBook[key].ContainsKey(moveKey))
                {
                    openingBook[key][moveKey] = 0;
                }

                openingBook[key][moveKey]++;

                state.ApplyMove(move);
                sequence.Add(moveKey);
            }
        }

        public void SaveToFile(string outputPath)
        {
            var json = JsonSerializer.Serialize(openingBook, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(outputPath, json);
            Debug.WriteLine("Opening book saved to " + outputPath);
        }
    }
}
