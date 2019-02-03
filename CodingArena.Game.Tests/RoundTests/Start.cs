using FluentAssertions;
using NUnit.Framework;
using System;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class Start : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            StartingEventArgs = null;
            StartedEventArgs = null;
            Round.Notifier.Starting += (sender, args) => StartingEventArgs = args;
            Round.Notifier.Started += (sender, args) => StartedEventArgs = args;
            Round.Controller.Start();
        }

        private EventArgs StartingEventArgs { get; set; }

        private EventArgs StartedEventArgs { get; set; }

        [Test]
        public void Starting_IsRaised() => StartingEventArgs.Should().NotBeNull();

        [Test]
        public void Started_IsRaised() => StartedEventArgs.Should().NotBeNull();
    }
}