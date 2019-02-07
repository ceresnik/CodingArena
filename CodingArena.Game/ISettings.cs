using System;

namespace CodingArena.Game
{
    public interface ISettings
    {
        int BattlefieldWidth { get; set; }
        int BattlefieldHeight { get; set; }
        int MaxRounds { get; set; }
        int MaxTurns { get; set; }
        TimeSpan NextRoundDelay { get; set; }
        TimeSpan NextTurnDelay { get; set; }
        int MaxHP { get; set; }
        int MaxSP { get; set; }
        int MaxEP { get; set; }
    }
}