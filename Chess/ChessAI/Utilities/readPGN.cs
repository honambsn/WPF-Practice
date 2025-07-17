using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessAI.Utilities
{
    public class readPGN
    {
        public string GameHeader { get; set; }
        public List<string> Moves_ { get; set; }

        public readPGN()
        {
            Moves_ = new List<string>();
        }

        public void LoadPGNfile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string pgnContent = File.ReadAllText(filePath);
                ParsePGN(pgnContent);
            }
            else
            {
                Debug.WriteLine($"File not found: {filePath}");
            }
        }

        private void ParsePGN(string pgnContent)
        {
            var headerRegex = new Regex(@"(\[.*?\])", RegexOptions.Singleline);
            var headers = headerRegex.Matches(pgnContent);

            foreach (Match header in headers)
            {
                GameHeader += header.Value + "\n";
            }

            var movesRegex = new Regex(@"([a-hA-H1-8\-+x#]+[\s]*)", RegexOptions.Singleline);
            var moves = movesRegex.Matches(pgnContent);

            foreach (Match move in moves)
            {
                Moves_.Add(move.Value.Trim());
            }
        }

        public void DisplayGameDetails()
        {
            Debug.WriteLine("Game Header:");
            Debug.WriteLine(GameHeader);

            Debug.WriteLine("Moves:");
            foreach (var move in Moves_)
            {
                Debug.WriteLine(move);
            }
        }

        public void SaveToPGN(string output)
        {
            string pgnContent = GameHeader + "\n";

            foreach (var move in Moves_)
            {
                pgnContent += move + " ";
            }

            File.WriteAllText(output, pgnContent.Trim());
            Debug.WriteLine($"PGN saved to {output}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            readPGN pgnReader = new readPGN();
            pgnReader.LoadPGNfile("file.pgn");
            pgnReader.DisplayGameDetails();

            string output = "output.pgn";
            pgnReader.SaveToPGN(output);
        }
    }
}
