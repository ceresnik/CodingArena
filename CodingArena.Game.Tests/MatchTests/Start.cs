using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class Start : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            IsStartedEventRaised = false;
            Match.Notifier.Started += (sender, args) => IsStartedEventRaised = true;
            Match.Controller.Start();
        }

        private bool IsStartedEventRaised { get; set; }

        [Test]
        public void Started_IsRaised() => IsStartedEventRaised.Should().BeTrue();
    }
}