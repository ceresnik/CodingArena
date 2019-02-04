using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class TestFixture : Tests.TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Round = Get<IRoundFactory>().Create(1);
        }

        protected IRound Round { get; private set; }
    }
}