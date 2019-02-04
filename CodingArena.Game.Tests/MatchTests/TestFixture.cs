using CodingArena.Game.Factories;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class TestFixture : Tests.TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Match = Get<IMatchFactory>().Create();
        }

        protected IMatch Match { get; private set; }
    }
}