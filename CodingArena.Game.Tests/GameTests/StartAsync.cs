using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.GameTests
{
    internal class StartAsync : TestFixture
    {
        [Test]
        public async Task Match_NotNull()
        {
            await Game.StartAsync();
            Game.Match.Should().NotBeNull();
        }

        [Test]
        public async Task MatchStarting_IsRaised()
        {
            bool isMatchStartingRaised = false;
            Game.MatchStarting += (sender, args) => isMatchStartingRaised = true;
            await Game.StartAsync();
            isMatchStartingRaised.Should().BeTrue();
        }

        [Test]
        public async Task MatchFinished_IsRaised()
        {
            bool isMatchFinishedRaised = false;
            Game.MatchFinished += (sender, args) => isMatchFinishedRaised = true;
            await Game.StartAsync();
            isMatchFinishedRaised.Should().BeTrue();
        }
    }
}