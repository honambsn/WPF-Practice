using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUI
{
    public enum GameModeOptions
    {
        BotMode,
        HumanMode,
        ResumeGame,
        PlayWithBot,
        PlayWithFriend,
        PlayOnline,
        Settings
    }

    public class ModeSelectedEventArgs : EventArgs
    {
        public GameModeOptions SelectedMode { get; }

        public ModeSelectedEventArgs(GameModeOptions mode)
        {
            SelectedMode = mode;
        }
    }
}
