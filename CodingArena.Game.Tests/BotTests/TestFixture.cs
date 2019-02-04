using CodingArena.Game.Factories;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class TestFixture : TestFixtureBase
    {
        protected IBattlefield Battlefield { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
        }
    }
}