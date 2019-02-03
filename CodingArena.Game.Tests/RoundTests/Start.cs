using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class Start : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            TurnStartingEventArgs = null;
            TurnStartedEventArgs = null;
            Round.Notifier.TurnStarting += (sender, args) => TurnStartingEventArgs = args;
            Round.Notifier.TurnStarted += (sender, args) => TurnStartedEventArgs = args;
            Round.Controller.Start();
        }

        private TurnEventArgs TurnStartingEventArgs { get; set; }

        private TurnEventArgs TurnStartedEventArgs { get; set; }

        [Test]
        public void TurnStarting_IsRaised() => TurnStartingEventArgs.Should().NotBeNull();

        [Test]
        public void TurnStarted_IsRaised() => TurnStartedEventArgs.Should().NotBeNull();
    }
}