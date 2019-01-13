using System;

namespace Game.Console
{
    internal class GameConfiguration
    {
        public GameConfiguration()
        {
            DelayForNextRound = TimeSpan.FromMinutes(5);
            BattlefieldSize = new Size(100, 100);
        }

        public TimeSpan DelayForNextRound { get; set; }
        public Size BattlefieldSize { get; set; }
    }
}