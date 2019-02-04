using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.MatchFactoryTests
{
    internal class Create : TestFixture
    {
        private IMatch Match { get; set; }

        public override void SetUp()
        {
            base.SetUp();
            Match = SUT.Create();
        }

        [Test]
        public void Match_NotNull() => Match.Should().NotBeNull();

        [Test]
        public void Match_Controller_NotNull() => Match.Controller.Should().NotBeNull();

        [Test]
        public void Match_Notifier_NotNull() => Match.Notifier.Should().NotBeNull();
    }
}