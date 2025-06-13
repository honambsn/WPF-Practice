using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUI
{
    public enum GameMode
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
        public GameMode SelectedMode { get; }

        public ModeSelectedEventArgs(GameMode mode)
        {
            SelectedMode = mode;
        }
    }
}
