using CodingArena.Game.Entities;
using NUnit.Framework;

namespace CodingArena.Game.Tests.GameTests
{
    internal class TestFixture : TestFixtureBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Game = Get<IGame>();
        }

        protected IGame Game { get; private set; }
    }
}