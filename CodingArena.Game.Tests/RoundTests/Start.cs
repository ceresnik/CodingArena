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
            var bot = BotWorkshop.Create(TestBotAI.Idle, Battlefield);
            BotFactory.Bots.Add(bot);
            var result = Round.Start();
            result.Should().NotBeNull();
            result.Scores.Should().NotBeNull();
            result.Scores.Count.Should().Be(1);
            result.Scores.First().BotName.Should().Be(bot.Name);
        }
    }
}