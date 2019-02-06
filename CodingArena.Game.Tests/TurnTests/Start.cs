using CodingArena.Game.Tests.BotAIs;
using NUnit.Framework;
using System.Collections.Generic;
using CodingArena.Game.Tests.Verification;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class Start : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Turn = TurnFactory.Create();
            AttackerBot = BotWorkshop.Create(TestBotAI.AttackFirstEnemy, Battlefield);
            IdleBot = BotWorkshop.Create(TestBotAI.Idle, Battlefield);
        }

        private ITurn Turn { get; set; }
        private IBattleBot AttackerBot { get; set; }
        private IBattleBot IdleBot { get; set; }

        [Test]
        public void AttackEnemy()
        {
            AttackerBot.PositionTo(0, 0);
            IdleBot.PositionTo(1, 0);
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            var result = Turn.Start(bots);
            Verify.That(result.BotActionResults[AttackerBot])
                .Is($"{AttackerBot.Name} attacks {IdleBot.Name} with 100 damage.");
            Verify.That(result.BotActionResults[IdleBot])
                .Is($"{IdleBot.Name} is idle.");
        }

        [Test]
        public void DestroyEnemy()
        {
            AttackerBot.PositionTo(0, 0);
            IdleBot.PositionTo(1, 0);
            IdleBot.TakeDamage(IdleBot.MaxSP + IdleBot.MaxHP - 1);
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            var result = Turn.Start(bots);
            Verify.That(result.BotActionResults[AttackerBot])
                .Is($"{AttackerBot.Name} attacks {IdleBot.Name} with 100 damage.");
            Verify.That(result.BotActionResults[IdleBot])
                .Is($"{IdleBot.Name} is destroyed by {AttackerBot.Name}.");
        }
    }
}