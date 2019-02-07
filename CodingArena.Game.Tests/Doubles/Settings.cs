using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(ISettings))]
    internal class Settings : ISettings
    {
        public Settings()
        {
            BattlefieldWidth = 50;
            BattlefieldHeight = 50;
            MaxRounds = 100;
            MaxTurns = 120;
            NextRoundDelay = TimeSpan.Zero;
            NextTurnDelay = TimeSpan.Zero;
            MaxHP = 500;
            MaxSP = 200;
            MaxEP = 500;
        }

        public int BattlefieldWidth { get; set; }

        public int BattlefieldHeight { get; set; }

        public int MaxRounds { get; set; }

        public int MaxTurns { get; set; }

        public TimeSpan NextRoundDelay { get; set; }

        public TimeSpan NextTurnDelay { get; set; }

        public int MaxHP { get; set; }

        public int MaxSP { get; set; }

        public int MaxEP { get; set; }
    }
}