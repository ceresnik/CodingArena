using System.Collections.Generic;
using System.ComponentModel.Composition;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        public BotFactory() => Bots = new List<IBattleBot>();

        public List<IBattleBot> Bots { get; set; }

        public IReadOnlyCollection<IBattleBot> Create(IBattlefield battlefield) => Bots;
    }
}