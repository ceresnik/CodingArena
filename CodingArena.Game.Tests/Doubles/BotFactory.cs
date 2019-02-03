using CodingArena.Game.Factories;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        public BotFactory()
        {
            BotsToCreate = new List<Bot>();
        }

        public List<Bot> BotsToCreate { get; }

        public IEnumerable<Bot> CreateBots(IBattlefield battlefield) => BotsToCreate;
    }
}