using CodingArena.Game.Internal;
using CodingArena.Player.Implement;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface IBotWorkshop
    {
        IBattleBot Create(IBotAI botAI, IBattlefield battlefield);
    }

    [Export(typeof(IBotWorkshop))]
    internal class BotWorkshop : IBotWorkshop
    {
        private ISettings Settings { get; }

        [ImportingConstructor]
        public BotWorkshop(ISettings settings)
        {
            Settings = settings;
        }

        public IBattleBot Create(IBotAI botAI, IBattlefield battlefield) =>
            new BattleBot(botAI, battlefield, Settings);
    }
}