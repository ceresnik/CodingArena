using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class Start : TestFixture
    {
        [Test]
        public async Task NoBots()
        {
            await Round.StartAsync();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Should().BeEmpty();
        }

        [Test]
        public async Task OneBot()
        {
            var bot = BotWorkshop.Create(TestBotAI.Idle);
            BotFactory.Bots.Add(bot);
            await Round.StartAsync();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(1);
            Round.Scores.First().BotName.Should().Be(bot.Name);
        }

        [Test]
        public async Task TwoBots()
        {
            var attacker = BotWorkshop.Create(TestBotAI.SeekAndDestroy("attacker"));
            attacker.PositionTo(Round.Battlefield, 0, 0);
            var victim = BotWorkshop.Create(TestBotAI.Idle);
            victim.PositionTo(Round.Battlefield, 1, 0);
            BotFactory.Bots.Add(attacker);
            BotFactory.Bots.Add(victim);
            await Round.StartAsync();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(2);
            Round.Scores.Single(s => s.BotName == attacker.Name).Kills.Should().Be(1);
            Round.Scores.Single(s => s.BotName == victim.Name).Deaths.Should().Be(1);
        }

        [Test]
        public async Task FiveBots()
        {
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot1")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot2")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot3")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot4")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot5")));
            await Round.StartAsync();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(5);
        }
    }
}