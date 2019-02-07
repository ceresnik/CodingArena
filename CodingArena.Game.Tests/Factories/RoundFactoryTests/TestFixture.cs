using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.Factories.RoundFactoryTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            RoundFactory = Get<IRoundFactory>();
        }

        protected IRoundFactory RoundFactory { get; private set; }
    }
}