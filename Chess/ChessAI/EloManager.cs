using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
    public class EloData
    {
        public int PlayerElo { get; set; } = 1200; // Default Elo rating for new players aka bots elo
        public int BotElo { get; set; } = 1200; // Default Elo rating for bots
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int TotalGames => Wins + Losses + Draws;
        //private string playerName;
        //private int playerElo;
        //public int EloRating { get; set; } = 1200; // Default Elo rating for new players aka bots elo
        //private int wins;
        //private int losses;
        //private int draws;
        //private DateTime lastUpdated;

        //public EloData(string playerName, int playerElo, int botElo, DateTime lastUpdated)
        //{
        //    PlayerName = playerName;
        //    PlayerElo = playerElo;
        //    EloRating = botElo;
        //    this.wins = 0;
        //    this.losses = 0;
        //    this.draws = 0;
        //    this.lastUpdated = lastUpdated;
        //}

        //public string PlayerName
        //{
        //    get => playerName;
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //            throw new ArgumentException("Player name cannot be null or empty.");
        //        playerName = value;
        //    }

        //}

        //public int PlayerElo
        //{
        //    get => playerElo;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Elo rating cannot be negative.");
        //        playerElo = value;
        //    }
        //}

        //public int BotElo
        //{
        //    get => EloRating;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Elo rating cannot be negative.");
        //        EloRating = value;
        //    }
        //}

        //public int Wins
        //{
        //    get => wins;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Wins cannot be negative.");
        //        wins = value;
        //    }
        //}
        //public int Losses
        //{
        //    get => losses;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Losses cannot be negative.");
        //        losses = value;
        //    }
        //}
        //public int Draws
        //{
        //    get => draws;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Draws cannot be negative.");
        //        draws = value;
        //    }
        //}

        //public int TotalGames
        //{
        //    get
        //    {
        //        return Wins + Losses + Draws;
        //    }
        //}

        //public DateTime LastUpdated
        //{
        //    get => lastUpdated;
        //    set
        //    {
        //        if (value > DateTime.Now)
        //            throw new ArgumentException("Last updated date cannot be in the future.");
        //        lastUpdated = value;
        //    }
        //}

        //public static class EloManager
        //{
        //    private static readonly string filePath = "eloData.json";
        //    private static EloData data;
        //    //private static List<EloData> eloList = new List<EloData>();

        //    static EloManager()
        //    {
        //        LoadEloData();
        //    }

        //    //public static int PlayerElo => eloList.FirstOrDefault()?.PlayerElo ?? 1200;
        //    public static int PlayerElo => data?.PlayerElo ?? 1200;

        //    private static void LoadEloData()
        //    {
        //        if (File.Exists(filePath))
        //        {
        //            string json = File.ReadAllText(filePath);
        //            data = JsonConvert.DeserializeObject<EloData>(json);
        //        }
        //        else
        //        {
        //            data = new EloData();
        //            Save();
        //        }
        //    }

        //    private static void Save()
        //    {
        //        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        //        File.WriteAllText(filePath, json);
        //    }
        //    public static void UpdateElo(bool playerWon)
        //    {
        //        int K = 32;
        //        double expectedScore = 1.0 / (1.0 + Math.Pow(10, (data.BotElo - data.PlayerElo) / 400.0));
        //        int playerScore = playerWon ? 1 : 0;

        //        data.PlayerElo += (int)(K * (playerScore - expectedScore));
        //        if (playerWon)
        //        {
        //            data.Wins++;
        //        }
        //        else
        //        {
        //            data.Losses++;
        //        }
        //    }

        //    public static int GetBotDepth()
        //    {
        //        // This is a placeholder for the bot depth logic.
        //        // You can implement your own logic to determine the bot's depth based on the Elo rating.
        //        if (data.PlayerElo < 1200)
        //        {
        //            return 1; // Beginner level
        //        }
        //        else if (data.PlayerElo < 1600)
        //        {
        //            return 2; // Intermediate level
        //        }
        //        else if (data.PlayerElo < 2000)
        //        {
        //            return 3; // Advanced level
        //        }
        //        else
        //        {
        //            return 4; // Expert level
        //        }
        //    }
        //}
    }
}
