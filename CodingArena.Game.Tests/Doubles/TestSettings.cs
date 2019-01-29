using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(ISettings))]
    internal class TestSettings : ISettings
    {
        public TestSettings()
        {
            BattlefieldWidth = 100;
            BattlefieldHeight = 100;
            MaxRounds = 12;
            MaxTurns = 100;
            NextRoundDelay = TimeSpan.FromMilliseconds(1);
            NextTurnActionDelay = TimeSpan.FromMilliseconds(1);
        }

        public int BattlefieldWidth { get; set; }
        public int BattlefieldHeight { get; set; }
        public int MaxRounds { get; set; }
        public int MaxTurns { get; set; }
        public TimeSpan NextRoundDelay { get; set; }
        public TimeSpan NextTurnActionDelay { get; set; }
    }
}