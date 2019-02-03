using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.RoundFactoryTests
{
    internal class Create : TestFixture
    {
        protected IRound Round { get; private set; }

        public override void SetUp()
        {
            base.SetUp();
            Round = SUT.Create();
        }

        [Test]
        public void Round_NotNull() => Round.Should().NotBeNull();

        [Test]
        public void Round_Controller_NotNull() => Round.Controller.Should().NotBeNull();

        [Test]
        public void Round_Notifier() => Round.Notifier.Should().NotBeNull();
    }
}