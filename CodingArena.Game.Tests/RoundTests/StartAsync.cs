using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class StartAsync : TestFixture
    {
        [Test]
        public async Task Turn_NotNull()
        {
            await Round.StartAsync();
            Round.Turn.Should().NotBeNull();
        }

        [Test]
        public async Task TurnStarting_IsRaised()
        {
            bool isTurnStartingRaised = false;
            Round.TurnStarting += (sender, args) => isTurnStartingRaised = true;
            await Round.StartAsync();
            isTurnStartingRaised.Should().BeTrue();
        }

        [Test]
        public async Task TurnFinished_IsRaised()
        {
            bool isTurnFinishedRaised = false;
            Round.TurnFinished += (sender, args) => isTurnFinishedRaised = true;
            await Round.StartAsync();
            isTurnFinishedRaised.Should().BeTrue();
        }
    }
}