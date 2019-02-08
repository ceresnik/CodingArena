using System.Linq;
using System.Threading.Tasks;
using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class StartAsync : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot1")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot2")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot3")));
        }

        [Test]
        public async Task Scores_Count()
        {
            await Match.StartAsync();
            Match.Scores.Should().NotBeNull();
            Match.Scores.Count().Should().Be(3);
        }

        [Test]
        public async Task RoundStarting_IsRaised()
        {
            bool isRoundStartingRaised = false;
            Match.RoundStarting += (sender, args) => isRoundStartingRaised = true;
            await Match.StartAsync();
            isRoundStartingRaised.Should().BeTrue();
        }

        [Test]
        public async Task RoundFinished_IsRaised()
        {
            bool isRoundFinishedRaised = false;
            Match.RoundFinished += (sender, args) => isRoundFinishedRaised = true;
            await Match.StartAsync();
            isRoundFinishedRaised.Should().BeTrue();
        }
    }
}