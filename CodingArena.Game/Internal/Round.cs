using System.Collections.Generic;

namespace CodingArena.Game.Internal
{
    internal class Round : IRound
    {
        public RoundResult Start() => new RoundResult(new List<Score>());
    }
}