using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChessAI.Config
{
    public class EloConfigEntry
    {
        public int Elo { get; set; }
        public int Depth { get; set; }
        public bool UseMoveOrdering { get; set; }
        public bool UseTT { get; set; }
        public int TimeLimitMs { get; set; }
    }

    public class BotDiffcultyConfig
    {
        //public BotDifficulty Difficulty { get; set; } = BotDifficulty.Medium; // Default difficulty level
        //public BotDifficultyConfig Easy { get; set; } = new BotDifficultyConfig { EloMax = 1200, Depth = 2 };
        //public BotDifficultyConfig Medium { get; set; } = new BotDifficultyConfig { EloMin = 1200, EloMax = 1600, Depth = 4 };
        //public BotDifficultyConfig Hard { get; set; } = new BotDifficultyConfig { EloMin = 1600, EloMax = 2000, Depth = 6 };
        //public BotDifficultyConfig Expert { get; set; } = new BotDifficultyConfig { EloMin = 2000, EloMax = 2400, Depth = 8 };
        
        public List<EloConfigEntry> EloConfigs { get; set; }

        public static BotDiffcultyConfig Load(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<BotDiffcultyConfig>(json) ?? new BotDiffcultyConfig();
        }

        public BotLevelConfig GetConfigForElo(int elo)
        {
            var closet = EloConfigs.OrderBy(entry => Math.Abs(entry.Elo - elo)).First();

            return new BotLevelConfig
            {
                Depth = closet.Depth,
                UseMoveOrdering = closet.UseMoveOrdering,
                UseTT = closet.UseTT,
                TimeLimitMs = closet.TimeLimitMs
            };

        }
    }
}
