using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.Factories.TurnFactoryTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            TurnFactory = Get<ITurnFactory>();
        }

        protected ITurnFactory TurnFactory { get; private set; }
    }
}