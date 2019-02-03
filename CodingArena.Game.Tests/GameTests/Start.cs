using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.GameTests
{
    internal class Start : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            MatchStartingEventArgs = null;
            SUT.Notifier.MatchStarting += (sender, args) => MatchStartingEventArgs = args;
            SUT.Controller.Start();
        }

        private MatchEventArgs MatchStartingEventArgs { get; set; }

        [Test]
        public void MatchStarting_IsRaised() => MatchStartingEventArgs.Should().NotBeNull();
    }
}