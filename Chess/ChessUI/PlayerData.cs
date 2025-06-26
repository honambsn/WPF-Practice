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
        private static readonly string filePath = "player_elo.txt";
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
            else
            {
                Debug.WriteLine("Invalid ELO value in file, resetting to default.");
                return defaultElo;
            }

        }

        public static void SaveElo(int elo)
        {
            Debug.WriteLine($"Saving ELO: {elo} to {filePath}");
        }
    }
}
