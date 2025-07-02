using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUI
{
    public static class PlayerData
    {
        //private static readonly string filePath = "Resources/elo_file.txt";
        private static readonly string filePath = Path.Combine(
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "elo_file.txt");


        //bonus solution, save the %appdata% for pro
        //        string filePath = Path.Combine(
        //    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        //    "MyChessApp", "player_elo.txt"
        //);
        //        Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Tạo folder nếu chưa có


        private static int defaultElo = 1200;

        public static int LoadElo()
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine("PlayerData - ELO file not found, creating with default value.");
                return defaultElo;
            }
                

            string content = File.ReadAllText(filePath);
            if (int.TryParse(content, out int elo))
            {
                Debug.WriteLine($"PlayerData - Loaded ELO: {elo} from {filePath}");
                return elo;
            }

            Debug.WriteLine("Invalid ELO value in file, resetting to default.");
            return defaultElo;
        }

        public static void SaveElo(int elo)
        {
            File.WriteAllText(filePath, elo.ToString());
            Debug.WriteLine($"Saving ELO: {elo} to {filePath}");
        }

        public static int UpdateEloAfterMatch(int currElo, int botElo, bool playerWon)
        {
            const int K = 32;
            double expected = 1.0 / (1 + Math.Pow(10, (botElo - currElo) / 400.0));
            double actual = playerWon ? 1.0 : 0.0;
            int newElo = (int)Math.Round(currElo + K * (actual - expected));
            newElo = Math.Max(100, newElo);
            SaveElo(newElo);

            Debug.WriteLine($"PlayerElo: {currElo}, BotElo: {botElo}, PlayerWon: {playerWon}");
            Debug.WriteLine($"Expected: {expected}, Actual: {actual}, ΔElo: {K * (actual - expected)}");
            return newElo;
        }
    }
}
