using CodingArena.Game.Entities;
using CodingArena.Game.Tests.Verification;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.RoundFactoryTests
{
    internal class Create : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Round = RoundFactory.Create(1);
        }

        private IRound Round { get; set; }

        [Test]
        public void Round_NotNull() => Round.Should().NotBeNull();

        [Test]
        public void RoundNumber() => Verify.That(Round.Number).Is(1);
    }
}