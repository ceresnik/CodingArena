﻿using System.IO;

namespace CodingArena.Game
{
    internal class GameEngine
    {
        private readonly GameConfiguration configuration;
        private readonly TextWriter textWriter;

        public GameEngine(GameConfiguration configuration, TextWriter textWriter)
        {
            this.configuration = configuration;
            this.textWriter = textWriter;
        }

        public IMatch CreateMatch() => new Match(textWriter, configuration);
    }
}