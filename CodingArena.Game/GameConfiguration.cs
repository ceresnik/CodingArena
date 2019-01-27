using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(GameConfiguration))]
    public class GameConfiguration
    {
        public TimeSpan TurnActionDelay { get; set; }
    }
}