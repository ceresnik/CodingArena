using CodingArena.Game.Internal;
using CodingArena.Player.Implement;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface IBotFactory
    {
        IBattleBot Create(IBotAI botAI, IBattlefield battlefield);
    }

    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        private ISettings Settings { get; }

        [ImportingConstructor]
        public BotFactory(ISettings settings)
        {
            Settings = settings;
        }

        public IBattleBot Create(IBotAI botAI, IBattlefield battlefield) =>
            new BattleBot(botAI, battlefield, Settings);
    }
}