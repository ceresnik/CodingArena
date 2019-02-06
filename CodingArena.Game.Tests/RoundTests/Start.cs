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
            var attacker = BotWorkshop.Create(TestBotAI.SeekAndDestroy);
            var victim = BotWorkshop.Create(TestBotAI.Idle);
            BotFactory.Bots.Add(attacker);
            BotFactory.Bots.Add(victim);
            var result = Round.Start();
            System.Console.WriteLine($"{victim.Name} HP={victim.HP}");
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Count.Should().Be(2);
            result.Scores.Single(s => s.BotName == attacker.Name).Kills.Should().Be(1);
            result.Scores.Single(s => s.BotName == victim.Name).Deaths.Should().Be(1);
        }
    }
}