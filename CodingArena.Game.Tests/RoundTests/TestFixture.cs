using CodingArena.Game.Factories;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class TestFixture : TestFixtureBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Round = Get<IRoundFactory>().Create();
        }

        protected IRound Round { get; private set; }
    }
}