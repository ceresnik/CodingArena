using CodingArena.Game.Tests.BotAIs;
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
            Assert.Fail("Not implemented");
        }
    }
}