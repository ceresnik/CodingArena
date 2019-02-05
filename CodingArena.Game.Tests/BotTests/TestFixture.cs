using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.BotTests
{
    internal class TestFixture : TestFixtureBase
    {
        protected TestBotAI BotAI { get; private set; }
        protected IBattlefield Battlefield { get; private set; }
        protected IBattleBot Bot { get; private set; }
        protected bool IsExplodedEventRaised { get; private set; }

        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
            BotAI = new TestBotAI();
            Bot = Get<IBotFactory>().Create(BotAI, Battlefield);
            IsExplodedEventRaised = false;
            Bot.Exploded += (sender, args) => IsExplodedEventRaised = true;
        }
    }
}