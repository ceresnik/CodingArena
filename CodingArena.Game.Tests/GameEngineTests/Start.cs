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
            StartedEventArgs = null;
            GameNotifier.Started += (sender, args) => StartedEventArgs = args;
            GameEngine.Start();
        }

        private GameStartingEventArgs StartedEventArgs { get; set; }

        [Test]
        public void Started_IsRaised() => StartedEventArgs.Should().NotBeNull();
    }
}