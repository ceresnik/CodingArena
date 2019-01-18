using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class GameConfiguration
    {
        public GameConfiguration()
        {
            //DelayForNextRound = TimeSpan.FromMinutes(5);
            DelayForNextRound = TimeSpan.FromMinutes(1);
            MaxRounds = 24; // 24 * 5 min = 2 hours
            MaxTurns = 100;
            BattlefieldSize = new BattlefieldSize(100, 100);
        }

        public TimeSpan DelayForNextRound { get; set; }

        public int MaxRounds { get; set; }

        public int MaxTurns { get; set; }

        public IBattlefieldSize BattlefieldSize { get; set; }
    }
}