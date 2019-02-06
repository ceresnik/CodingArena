using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class Start : TestFixture
    {
        [Test]
        public void NoBots()
        {
            var result = Round.Start();
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Should().BeEmpty();
        }
    }
}