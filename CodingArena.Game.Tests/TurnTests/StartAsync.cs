using CodingArena.Game.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class StartAsync : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            AttackerBot.PositionTo(Battlefield, 0, 0);
            IdleBot.PositionTo(Battlefield, 1, 0);
        }

        [Test]
        public async Task BotActions_NotNull()
        {
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            await Turn.StartAsync(bots);
            Turn.BotActions.Should().NotBeNull();
        }
    }
}