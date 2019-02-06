using System.Linq;
using CodingArena.Game.Tests.BotAIs;
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

        [Test]
        public void OneBot()
        {
            var bot = BotWorkshop.Create(TestBotAI.Idle);
            BotFactory.Bots.Add(bot);
            var result = Round.Start();
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Count.Should().Be(1);
            result.Scores.First().BotName.Should().Be(bot.Name);
        }

        [Test]
        public void TwoBots()
        {
            var attacker = BotWorkshop.Create(TestBotAI.SeekAndDestroy("attacker"));
            var victim = BotWorkshop.Create(TestBotAI.Idle);
            BotFactory.Bots.Add(attacker);
            BotFactory.Bots.Add(victim);
            var result = Round.Start();
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Count.Should().Be(2);
            result.Scores.Single(s => s.BotName == attacker.Name).Kills.Should().Be(1);
            result.Scores.Single(s => s.BotName == victim.Name).Deaths.Should().Be(1);
        }

        [Test]
        public void FiveBots()
        {
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot1")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot2")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot3")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot4")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot5")));
            var result = Round.Start();
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Count.Should().Be(5);
        }
    }
}