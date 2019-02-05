using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class Start : TestFixture
    {
        [Test]
        public void AttackClosestEnemy()
        {
            var turn = TurnFactory.Create();
            var attackerBot = BotFactory.Create(TestBotAI.AttackClosest, Battlefield);
            var idleBot = BotFactory.Create(TestBotAI.Idle, Battlefield);
            var bots = new List<IBattleBot> { attackerBot, idleBot };
            TurnResult result = turn.Start(bots);
            result.Kills[attackerBot].Should().Be(1);
            result.Kills[idleBot].Should().Be(0);
            result.Deaths[attackerBot].Should().Be(0);
            result.Deaths[idleBot].Should().Be(1);
        }
    }
}