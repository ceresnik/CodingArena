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
            Match.Notifier.Starting += (sender, args) => StartingEventArgs = args;
            Match.Notifier.Started += (sender, args) => StartedEventArgs = args;
            Match.Controller.Start();
        }

        private RoundEventArgs StartingEventArgs { get; set; }

        private EventArgs StartedEventArgs { get; set; }

        [Test]
        public void Starting_IsRaised()
        {
            StartingEventArgs.Should().NotBeNull();
            StartingEventArgs.RoundNotifier.Should().NotBeNull(nameof(StartingEventArgs.RoundNotifier));
        }

        [Test]
        public void Started_IsRaised() => StartedEventArgs.Should().NotBeNull();
    }
}