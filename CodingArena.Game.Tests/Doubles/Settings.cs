using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(ISettings))]
    internal class Settings : ISettings
    {
        public Settings()
        {
            BattlefieldWidth = 100;
            BattlefieldHeight = 100;
            MaxRounds = 100;
            MaxTurns = 120;
            NextRoundDelay = TimeSpan.Zero;
            NextTurnActionDelay = TimeSpan.Zero;
        }

        public int BattlefieldWidth { get; set; }

        public int BattlefieldHeight { get; set; }

        public int MaxRounds { get; set; }

        public int MaxTurns { get; set; }

        public TimeSpan NextRoundDelay { get; set; }

        public TimeSpan NextTurnActionDelay { get; set; }
    }
}