using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class Start : TestFixture
    {
        private MatchResult MatchResult { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot1")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot2")));
            BotFactory.Bots.Add(BotWorkshop.Create(TestBotAI.SeekAndDestroy("bot3")));
            MatchResult = Match.Start();
        }

        [Test]
        public void Scores_Count()
        {
            MatchResult.Scores.Should().NotBeNull();
            MatchResult.Scores.Count.Should().Be(3);
        }
    }
}