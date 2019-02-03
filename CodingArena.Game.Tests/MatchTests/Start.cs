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
            Match.Notifier.Started += (sender, args) => StartedEventArgs = args;
            Match.Controller.Start();
        }

        private EventArgs StartedEventArgs { get; set; }

        [Test]
        public void Started_IsRaised() => StartedEventArgs.Should().NotBeNull();
    }
}