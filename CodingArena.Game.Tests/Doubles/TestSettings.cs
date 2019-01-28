using System;
using System.ComponentModel.Composition;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(ISettings))]
    internal class TestSettings : ISettings
    {
        public TestSettings()
        {
            BattlefieldSize = new Size(100, 100);
            MaxRounds = 12;
            MaxTurns = 100;
            NextRoundDelay = TimeSpan.FromMilliseconds(1);
            NextTurnActionDelay = TimeSpan.FromMilliseconds(1);
        }

        public Size BattlefieldSize { get; set; }
        public int MaxRounds { get; set; }
        public int MaxTurns { get; set; }
        public TimeSpan NextRoundDelay { get; set; }
        public TimeSpan NextTurnActionDelay { get; set; }
    }
}