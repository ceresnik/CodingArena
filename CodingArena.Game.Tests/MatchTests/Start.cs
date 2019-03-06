using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class Start : TestFixture
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
    }
}