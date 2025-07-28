using ChessLogic;
using ChessLogic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.OpeningBook
{
    public static class OpeningBookFormat
    {
        public static void Save(Dictionary<ulong, Dictionary<Move, int>> raw, string path)
        {
            var list = new List<string>();

            foreach (var kvp in raw)
            {
                foreach (var moveFreq in kvp.Value)
                {
                    //list.Add($"{kvp.Key:X16} {moveFreq.Key} {moveFreq.Value}");
                    //list.Add($"{kvp.Key};{moveFreq.Key.ToAlgebraic()};{moveFreq.Value}");
                    list.Add($"{kvp.Key};{moveFreq.Key.ToAlgebraic()};{moveFreq.Value}");
                }
            }

            File.WriteAllLines(path, list);
        }

        public static Dictionary<ulong, List<OpeningEntry>> Load(string path)
        {
            var dict = new Dictionary<ulong, List<OpeningEntry>>();
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 3) continue; // Skip invalid lines

                var hash = ulong.Parse(parts[0]);
                var notation = parts[1];
                var freq = int.Parse(parts[2]);

                //var state = new GameState(Player.White, Board.Initial());
                //var move = AlgebraicNotationHelper.FromAlgebraic(notation, state);

                if (!dict.ContainsKey(hash))
                {
                    //                    dict[hash] = new List<OpeningEntry>();
                    dict[hash] = new();
                }

                dict[hash].Add(new OpeningEntry(notation, freq));

            }

            return dict;
        }
    }
}
