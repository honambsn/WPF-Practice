using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessLogic.Helper.PGN
{
    public static class PGNReader
    {
        // read 1 game
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


        // read all games in PGN file
        // no remove time
        public static List<List<string>> ReadPGN(string filePath)
        {
            List<List<string>> gameMoves = new List<List<string>>();

            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                throw new FileNotFoundException("The specified PGN file does not exist.", filePath);
            }

            string[] lines = File.ReadAllLines(filePath);
            List<string> currMoves = new List<string>();
            bool inMoves = false;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("["))
                {
                    if (currMoves.Count > 0)
                    {
                        gameMoves.Add(new List<string>(currMoves));
                        currMoves.Clear();
                    }

                    inMoves = false;
                    continue;
                }

                inMoves = true;

                if (inMoves)
                {
                    string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var token in tokens)
                    {
                        if (Regex.IsMatch(token, @"^\d+\.")) continue;

                        if (token == "1-0" || token == "0-1" || token == "1/2-1/2") continue;

                        currMoves.Add(token);
                    }
                }
            }

            if (currMoves.Count > 0)
            {
                gameMoves.Add(new List<string>(currMoves));
            }
            return gameMoves;
        }

        // remove time
        public static List<List<string>> ReadGamesFromPGN(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                throw new FileNotFoundException("The specified PGN file does not exist.", filePath);
            }

            string content = File.ReadAllText(filePath);

            string[] gameSections = content.Split(new[] { "[Event " }, StringSplitOptions.RemoveEmptyEntries);

            var allGames = new List<List<string>>();
            foreach (var section in gameSections)
            {
                string gameText = "[Event " + section.Trim();

                int lastBacketIndex = gameText.LastIndexOf(']');
                if (lastBacketIndex < 0 || lastBacketIndex + 1 >= gameText.Length) continue;

                string movesText = gameText.Substring(lastBacketIndex + 1).Trim();

                movesText = Regex.Replace(movesText, @"\{[^}]*\}", ""); // remove time

                movesText = movesText.Replace("1-0", "")
                                     .Replace("0-1", "")
                                     .Replace("1/2-1/2", "");

                movesText = Regex.Replace(movesText, @"\d+\.", ""); // remove move numbers order

                // Split the moves by whitespace and newlines
                var tokens = movesText.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var moves = new List<string>();
                foreach (var token in tokens)
                {
                    if (!string.IsNullOrEmpty(token))
                        moves.Add(token.Trim());
                }

                if (moves.Count > 0)
                {
                    allGames.Add(moves);
                }

            }

            return allGames;
        }

        // read all games in PGN file
        public static List<List<string>> ReadMovesPGN(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                throw new FileNotFoundException("The specified PGN file does not exist.", filePath);
            }

            string content = File.ReadAllText(filePath);

            // Split the content into individual games based on the PGN format
            var games = content.Split(new[] { "[Event " }, StringSplitOptions.RemoveEmptyEntries);

            List<List<string>> allGameMoves = new();

            foreach (var game in games)
            {
                // add [Event to restore the game format if needed
                string fullGame = "[Event " + game.Trim();

                // Find the last closing bracket to isolate the moves
                int lastBracketIndex = fullGame.LastIndexOf(']');
                if (lastBracketIndex == -1 || lastBracketIndex + 1 >= fullGame.Length) continue;

                // Extract the moves part of the game
                string moveSection = fullGame.Substring(lastBracketIndex + 1).Trim();

                // Remove time annotations and other non-move text
                moveSection = Regex.Replace(moveSection, @"\{[^}]*\}", ""); // remove time annotations

                // remove result annotations
                moveSection = moveSection.Replace("1-0", "")
                                         .Replace("0-1", "")
                                         .Replace("1/2-1/2", "");

                // remove move numbers
                moveSection = Regex.Replace(moveSection, @"\d+\.", ""); // remove move numbers


                // split moves
                var tokens = moveSection.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var gameMoves = new List<string>();
                foreach (var token in tokens)
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        gameMoves.Add(token.Trim());
                    }
                }

                if (gameMoves.Count > 0)
                {
                    allGameMoves.Add(gameMoves);
                }

            }

            return allGameMoves;
        } // use =>
          //var allGames = ReadMovesFromPGN("path_to_your_pgn_file.pgn");
          //foreach (var game in allGames)
          //{
          //    console.WriteLine("New game");
          //    Console.WriteLine(string.Join(" ", game));
          //}


        public static (string eventDetails, List<string> moves) ParsePgn(string pgnContent)
        {
            string eventDetails = ExtractEventDetails(pgnContent);
            List<string> moves = ExtractMoves(pgnContent);

            return (eventDetails, moves);
        }

        private static string ExtractEventDetails(string pgnContent)
        {
            string pattern = @"\[([A-Za-z]+) ""([^""]+)""\]";
            var matches = Regex.Matches(pgnContent, pattern);

            string eventDetails = "";
            foreach (Match match in matches)
            {
                eventDetails += $"{match.Groups[1].Value}: {match.Groups[2].Value}\n";
            }

            return eventDetails;
        }

        private static List<string> ExtractMoves(string pgnContent)
        {
            List<string> moves = new List<string>();

            string cleanedPgn = Regex.Replace(pgnContent, @"{\[%clk.*?\]}", string.Empty);

            cleanedPgn = Regex.Replace(cleanedPgn, @"\[[^\]]*\]", string.Empty);

            string[] moveParts = cleanedPgn.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in moveParts)
            {
                //if (part == "1-0" || part == "0-1" || part == "1/2-1/2" || Regex.IsMatch(part, @"^\d+\.$"))
                if (part == "1-0" || part == "0-1" || part == "1/2-1/2")

                {
                    break;
                }

                moves.Add(part);
            }

            return moves;
        }


        //public class PgnParser
        //{
        //    // Phương thức phân tích PGN và trả về thông tin sự kiện và các nước đi của mỗi ván cờ.
        //    public static List<(string eventDetails, List<string> moves)> ParsePgn(string pgnContent)
        //    {
        //        List<string> pgnGames = ExtractGames(pgnContent);

        //        List<(string eventDetails, List<string> moves)> gameData = new List<(string, List<string>)>();

        //        foreach (var game in pgnGames)
        //        {
        //            // Lấy metadata và các nước đi của từng ván cờ
        //            string eventDetails = ExtractEventDetails(game);
        //            List<string> moves = ExtractMoves(game);

        //            gameData.Add((eventDetails, moves));
        //        }

        //        return gameData;
        //    }

        //    // Phương thức trích xuất các ván cờ từ file PGN
        //    private static List<string> ExtractGames(string pgnContent)
        //    {
        //        var games = new List<string>();
        //        string[] splitGames = pgnContent.Split(new string[] { "\n\n\n" }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string game in splitGames)
        //        {
        //            games.Add(game);
        //        }
        //        return games;
        //    }

        //    // Phương thức trích xuất metadata của sự kiện từ ván cờ
        //    private static string ExtractEventDetails(string pgnGame)
        //    {
        //        string pattern = @"\[([A-Za-z]+) ""([^""]+)""\]";
        //        var matches = Regex.Matches(pgnGame, pattern);

        //        string eventDetails = "";
        //        foreach (Match match in matches)
        //        {
        //            eventDetails += $"{match.Groups[1].Value}: {match.Groups[2].Value}\n";
        //        }

        //        return eventDetails;
        //    }

        //    // Phương thức trích xuất các nước đi của ván cờ
        //    private static List<string> ExtractMoves(string pgnGame)
        //    {
        //        List<string> moves = new List<string>();

        //        // Làm sạch đồng hồ
        //        string cleanedPgn = Regex.Replace(pgnGame, @"{\[%clk.*?\]}", string.Empty);

        //        // Xóa metadata như Event, Date, v.v.
        //        cleanedPgn = Regex.Replace(cleanedPgn, @"\[[^\]]*\]", string.Empty);

        //        // Trích xuất các nước đi (mọi thứ sau metadata)
        //        string[] moveParts = cleanedPgn.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //        foreach (var part in moveParts)
        //        {
        //            // Bỏ qua kết quả ván cờ (1-0, 0-1, 1/2-1/2)
        //            if (part == "1-0" || part == "0-1" || part == "1/2-1/2")
        //            {
        //                break;
        //            }

        //            moves.Add(part);
        //        }

        //        return moves;
        //    }
        //}

        public class PgnParser
        {
            // Phương thức phân tích PGN và trả về thông tin sự kiện và các nước đi của mỗi ván cờ.
            public static List<(string eventDetails, List<string> moves)> ParsePgn(string pgnContent)
            {
                List<string> pgnGames = ExtractGames(pgnContent);

                List<(string eventDetails, List<string> moves)> gameData = new List<(string, List<string>)>();

                foreach (var game in pgnGames)
                {
                    // Lấy metadata và các nước đi của từng ván cờ
                    string eventDetails = ExtractEventDetails(game);
                    List<string> moves = ExtractMoves(game);

                    gameData.Add((eventDetails, moves));
                }

                return gameData;
            }

            // Phương thức trích xuất các ván cờ từ file PGN
            private static List<string> ExtractGames(string pgnContent)
            {
                var games = new List<string>();
                string[] splitGames = pgnContent.Split(new string[] { "\n\n\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string game in splitGames)
                {
                    games.Add(game);
                }
                return games;
            }

            // Phương thức trích xuất metadata của sự kiện từ ván cờ
            private static string ExtractEventDetails(string pgnGame)
            {
                string pattern = @"\[([A-Za-z]+) ""([^""]+)""\]";
                var matches = Regex.Matches(pgnGame, pattern);

                string eventDetails = "";
                foreach (Match match in matches)
                {
                    eventDetails += $"{match.Groups[1].Value}: {match.Groups[2].Value}\n";
                }

                return eventDetails;
            }

            // Phương thức trích xuất các nước đi của ván cờ
            private static List<string> ExtractMoves(string pgnGame)
            {
                List<string> moves = new List<string>();

                // Làm sạch đồng hồ
                string cleanedPgn = Regex.Replace(pgnGame, @"{\[%clk.*?\]}", string.Empty);

                // Xóa metadata như Event, Date, v.v.
                cleanedPgn = Regex.Replace(cleanedPgn, @"\[[^\]]*\]", string.Empty);

                // Trích xuất các nước đi (mọi thứ sau metadata)
                string[] moveParts = cleanedPgn.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in moveParts)
                {
                    // Bỏ qua kết quả ván cờ (1-0, 0-1, 1/2-1/2)
                    if (part == "1-0" || part == "0-1" || part == "1/2-1/2")
                    {
                        break;
                    }

                    moves.Add(part);
                }

                return moves;
            }
        }
    }
}
