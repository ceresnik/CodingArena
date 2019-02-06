using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.RoundFactoryTests
{
    internal class Create : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Round = RoundFactory.Create();
        }

        private IRound Round { get; set; }

        [Test]
        public void Round_NotNull() => Round.Should().NotBeNull();
    }
}