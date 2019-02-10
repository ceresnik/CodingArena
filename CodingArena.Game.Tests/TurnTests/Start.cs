using CodingArena.Game.Entities;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class Start : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            AttackerBot.PositionTo(Battlefield, 0, 0);
        }

        [Test]
        public void AttackEnemy()
        {
            IdleBot.PositionTo(Battlefield, 1, 0);
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            Turn.Start(bots);
            Verify.That(AttackerBot.Action)
                .Is($"{AttackerBot.Name} attacks {IdleBot.Name} with 100 damage.");
            Verify.That(IdleBot.Action)
                .Is($"{IdleBot.Name} is idle.");
        }

        [Test]
        public void DestroyEnemy()
        {
            IdleBot.PositionTo(Battlefield, 1, 0);
            IdleBot.TakeDamage(IdleBot.MaxSP + IdleBot.MaxHP - 1);
            var bots = new List<IBattleBot> { AttackerBot, IdleBot };
            Turn.Start(bots);
            Verify.That(AttackerBot.Action)
                .Is($"{AttackerBot.Name} destroys {IdleBot.Name}.");
            Verify.That(IdleBot.Action)
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
                System.Console.WriteLine($"Attacker: {attacker.Position}");
                System.Console.WriteLine($"Victim:   {victim.Position}");
                var turn = TurnFactory.Create(i);
                turn.Start(bots);
                System.Console.WriteLine(attacker.Action);
            }

            victim.HP.Should().Be(0);
        }
    }
}