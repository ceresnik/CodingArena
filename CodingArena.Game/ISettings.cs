using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface ISettings
    {
        Size BattlefieldSize { get; set; }
        int MaxRounds { get; set; }
        int MaxTurns { get; set; }
        TimeSpan NextRoundDelay { get; set; }
    }
}