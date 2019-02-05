using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
            BotFactory = Get<IBotFactory>();
            TurnFactory = Get<ITurnFactory>();
        }

        protected IBattlefield Battlefield { get; private set; }
        protected IBotFactory BotFactory { get; private set; }
        protected ITurnFactory TurnFactory { get; private set; }
    }
}