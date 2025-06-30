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
        private static readonly string filePath = "Resources/player_elo.txt";
        private static int defaultElo = 1200;

        public static int LoadElo()
        {
            if (!File.Exists(filePath))
                return defaultElo;

            string content = File.ReadAllText(filePath);
            if (int.TryParse(content, out int elo))
            {
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
            return newElo;
        }
    }
}
