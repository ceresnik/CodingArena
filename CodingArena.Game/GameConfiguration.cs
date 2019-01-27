using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(GameConfiguration))]
    public class GameConfiguration
    {
        public GameConfiguration()
        {
            MaxTurns = 100;
        }

        public int MaxTurns { get; set; }

        public TimeSpan TurnActionDelay { get; set; }
    }
}