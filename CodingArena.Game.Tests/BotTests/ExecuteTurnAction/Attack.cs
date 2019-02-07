using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class Attack : TestFixture
    {
        private IBattleBot Enemy { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Enemy = Get<IBotWorkshop>().Create(TestBotAI.Idle);
            var turnAction = TurnAction.Attack(Enemy.OutsideView);
            BotAI.TurnAction = turnAction;
            EnergyCost = BotAI.TurnAction.EnergyCost;
        }

        [Test]
        public void OutOfRange()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            Enemy.PositionTo(Battlefield, 11, 0);
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(Enemy.MaxHP);
            Verify.That(Enemy.SP).Is(Enemy.MaxSP);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
        }

        [TestCase(1, 100)]
        [TestCase(2, 80)]
        [TestCase(3, 60)]
        [TestCase(4, 40)]
        [TestCase(5, 20)]
        public void InRange(int distance, int damage)
        {
            Bot.PositionTo(Battlefield, 0, 0);
            Enemy.PositionTo(Battlefield, distance, 0);
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(Enemy.MaxHP);
            Verify.That(Enemy.SP).Is(Enemy.MaxSP - damage);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
        }

        [Test]
        public void FullDamageOnLowShield()
        {
            const int damage = Player.TurnActions.Attack.MaxDamage;
            Bot.PositionTo(Battlefield, 0, 0);
            Enemy.PositionTo(Battlefield, 1, 0);
            Enemy.TakeDamage(Enemy.MaxSP + 1);
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(Enemy.MaxHP - damage - 1);
            Verify.That(Enemy.SP).Is(0);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
        }

        [Test]
        public void DestroyEnemy()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            Enemy.PositionTo(Battlefield, 1, 0);
            Enemy.TakeDamage(Enemy.MaxSP + Enemy.MaxHP - 1);
            var isEnemyExplodedEventRaised = false;
            Enemy.Exploded += (sender, args) => isEnemyExplodedEventRaised = true;
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(0);
            Verify.That(Enemy.SP).Is(0);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
            Verify.That(isEnemyExplodedEventRaised).IsTrue();
            Verify.That(Enemy.DestroyedBy).Is(Bot.Name);
            Verify.That(Bot.Kills).Is(1);
            Verify.That(Enemy.Deaths).Is(1);
        }

        [Test]
        public void OutOfEnergy()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            Bot.DrainEnergy(Bot.EP);
            Enemy.PositionTo(Battlefield, 1, 0);
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(0);
            Verify.That(Enemy.HP).Is(Enemy.MaxHP);
            Verify.That(Enemy.SP).Is(Enemy.MaxSP);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
        }

        [Test]
        public void DestroyedEnemy()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            Enemy.PositionTo(Battlefield, 1, 0);
            Enemy.TakeDamage(Enemy.MaxSP + Enemy.MaxHP);
            var isEnemyExplodedEventRaised = false;
            Enemy.Exploded += (sender, args) => isEnemyExplodedEventRaised = true;
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(0);
            Verify.That(Enemy.SP).Is(0);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
            Verify.That(isEnemyExplodedEventRaised).IsFalse();
            Verify.That(Bot.Kills).Is(0);
            Verify.That(Enemy.Deaths).Is(1);
        }
    }
}