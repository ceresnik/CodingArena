using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(GameConfiguration))]
    public class GameConfiguration
    {
        public GameConfiguration()
        {
            MaxRounds = 24; // 24 * 5 min = 2 hours
            MaxTurns = 100;
        }

        public int MaxRounds { get; set; }

        public int MaxTurns { get; set; }

        public TimeSpan TurnActionDelay { get; set; }
    }
}