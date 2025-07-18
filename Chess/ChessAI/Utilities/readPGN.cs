using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessAI.Utilities
{
    public static class readPGN
    {
        public static List<string> ReadMovesFromPGN(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                throw new FileNotFoundException("The specified PGN file does not exist.", filePath);
            }

            var lines = File.ReadAllLines(filePath);
            Debug.WriteLine($"Lines in PGN file: {lines.Length}");

            Debug.WriteLine($"Line: {lines}");

            foreach (var line in lines)
            {
                Debug.WriteLine($"Line: {line}");
            }
            
            var moves = new List<string>();

            var movePattern = new Regex(@"\d+\.\s*([^\s]+)\s+([^\s]+)?");

            foreach (var line in lines)
            {
                if (line.StartsWith("[") || string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var matches = movePattern.Matches(line);

                foreach (Match match in matches)
                {
                    if (match.Groups.Count >= 2)
                        moves.Add(match.Groups[1].Value); // Add the first move

                    if (match.Groups.Count >= 3 && !string.IsNullOrEmpty(match.Groups[2].Value))
                        moves.Add(match.Groups[2].Value); // Add the second move if it exists
                }
            }
            return moves;
        }
    }
}
