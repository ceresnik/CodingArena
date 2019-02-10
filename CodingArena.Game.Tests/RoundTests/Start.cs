using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class Start : TestFixture
    {
        [Test]
        public void NoBots()
        {
            Round.Start();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Should().BeEmpty();
        }

        [Test]
        public void OneBot()
        {
            var bot = BotWorkshop.Create(TestBotAI.Idle);
            BotFactory.Bots.Add(bot);
            Round.Start();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(1);
            Round.Scores.First().BotName.Should().Be(bot.Name);
        }

        [Test]
        public void TwoBots()
        {
            var attacker = BotWorkshop.Create(TestBotAI.SeekAndDestroy("attacker"));
            attacker.PositionTo(Round.Battlefield, 0, 0);
            var victim = BotWorkshop.Create(TestBotAI.Idle);
            victim.PositionTo(Round.Battlefield, 1, 0);
            BotFactory.Bots.Add(attacker);
            BotFactory.Bots.Add(victim);
            Round.Start();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(2);
            Round.Scores.Single(s => s.BotName == attacker.Name).Kills.Should().Be(1);
            Round.Scores.Single(s => s.BotName == victim.Name).Deaths.Should().Be(1);
        }

        [Test]
        public void FiveBots()
        {
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot1")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot2")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot3")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot4")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot5")));
            Round.Start();
            Round.Scores.Should().NotBeNull();
            Round.Scores.Count().Should().Be(5);
        }
    }
}