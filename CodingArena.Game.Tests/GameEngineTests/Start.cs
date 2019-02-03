using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.GameEngineTests
{
    internal class Start : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            IsStartedEventRaised = false;
            GameNotifier.Started += (sender, args) => IsStartedEventRaised = true;
            GameEngine.Start();
        }

        private bool IsStartedEventRaised { get; set; }

        [Test]
        public void Started_IsRaised() => IsStartedEventRaised.Should().BeTrue();
    }
}