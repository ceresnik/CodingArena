using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.Factories.MatchFactoryTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            MatchFactory = Get<IMatchFactory>();
        }

        protected IMatchFactory MatchFactory { get; private set; }
    }
}