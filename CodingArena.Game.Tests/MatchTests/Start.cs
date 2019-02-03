using FluentAssertions;
using NUnit.Framework;
using System;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class Start : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            StartedEventArgs = null;
            Match.Notifier.RoundStarting += (sender, args) => StartingEventArgs = args;
            Match.Notifier.RoundStarted += (sender, args) => StartedEventArgs = args;
            Match.Controller.Start();
        }

        private RoundEventArgs StartingEventArgs { get; set; }

        private EventArgs StartedEventArgs { get; set; }

        [Test]
        public void Starting_IsRaised()
        {
            StartingEventArgs.Should().NotBeNull();
            StartingEventArgs.Round.Should().NotBeNull(nameof(StartingEventArgs.Round));
        }

        [Test]
        public void Started_IsRaised() => StartedEventArgs.Should().NotBeNull();
    }
}