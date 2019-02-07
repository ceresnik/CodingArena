using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.Factories.BattlefieldFactoryTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            BattlefieldFactory = Get<IBattlefieldFactory>();
        }

        protected IBattlefieldFactory BattlefieldFactory { get; private set; }
    }
}