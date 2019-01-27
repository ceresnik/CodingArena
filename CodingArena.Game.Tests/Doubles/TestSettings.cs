using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Tests.Doubles
{
    internal class TestSettings : ISettings
    {
        public TestSettings()
        {
            BattlefieldSize = new Size(100, 100);
            NextRoundDelay = TimeSpan.MinValue;
        }

        public Size BattlefieldSize { get; set; }
        public TimeSpan NextRoundDelay { get; set; }
    }
}