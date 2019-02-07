using CodingArena.Game.Tests.BotAIs;
using NUnit.Framework;
using System.Collections.Generic;
using CodingArena.Game.Entities;
using CodingArena.Game.Tests.Verification;
using FluentAssertions;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class Start : TestFixture
    {
        private ITurn Turn { get; set; }
        private IBattleBot AttackerBot { get; set; }
        private IBattleBot IdleBot { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Turn = TurnFactory.Create(1);
            AttackerBot = BotWorkshop.Create(TestBotAI.AttackFirstEnemy);
            IdleBot = BotWorkshop.Create(TestBotAI.Idle);
            AttackerBot.PositionTo(Battlefield, 0, 0);
            IdleBot.PositionTo(Battlefield, 1, 0);
        }

        [Test]
        public void AttackEnemy()
        {
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            Turn.Start(bots);
            Verify.That(Turn.BotActions[AttackerBot])
                .Is($"{AttackerBot.Name} attacks {IdleBot.Name} with 100 damage.");
            Verify.That(Turn.BotActions[IdleBot])
                .Is($"{IdleBot.Name} is idle.");
        }

        [Test]
        public void DestroyEnemy()
        {

            IdleBot.TakeDamage(IdleBot.MaxSP + IdleBot.MaxHP - 1);
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            Turn.Start(bots);
            Verify.That(Turn.BotActions[AttackerBot])
                .Is($"{AttackerBot.Name} destroys {IdleBot.Name}.");
            Verify.That(Turn.BotActions[IdleBot])
                .Is($"{IdleBot.Name} is destroyed by {AttackerBot.Name}.");
        }

        [Test]
        public void ItIsPossibleToKill()
        {
            var attacker = BotWorkshop.Create(TestBotAI.SeekAndDestroy("attacker"));
            var victim = BotWorkshop.Create(TestBotAI.Idle);
            var bots = new List<IBattleBot> { attacker, victim };
            attacker.PositionTo(Battlefield, 0, 0);
            victim.PositionTo(Battlefield, Battlefield.Width - 1, Battlefield.Height - 1);
            for (int i = 1; i <= Settings.MaxTurns; i++)
            {
                var turn = TurnFactory.Create(i);
                turn.Start(bots);
            }

            victim.HP.Should().Be(0);
        }
    }
}