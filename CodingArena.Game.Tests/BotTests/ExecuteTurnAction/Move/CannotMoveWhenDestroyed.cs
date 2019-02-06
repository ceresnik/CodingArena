using System.Collections.Generic;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class CannotMoveWhenDestroyed : TestFixture
    {
        private IBattleBot Attacker { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Bot.PositionTo(1, 1);
            Attacker = Get<IBotWorkshop>().Create(TestBotAI.AttackFirstEnemy, Battlefield);
            Bot.TakeDamage(Bot.MaxHP + Bot.MaxHP, Attacker);
        }

        [Test]
        public void MoveEast()
        {
            BotAI.TurnAction = TurnAction.Move.East();
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 1);
            Verify.That(result).Is($"{Bot.Name} is destroyed by {Attacker.Name}.");
        }

        [Test]
        public void MoveWest()
        {
            BotAI.TurnAction = TurnAction.Move.West();
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 1);
            Verify.That(result).Is($"{Bot.Name} is destroyed by {Attacker.Name}.");
        }

        [Test]
        public void MoveSouth()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 1);
            Verify.That(result).Is($"{Bot.Name} is destroyed by {Attacker.Name}.");
        }

        [Test]
        public void MoveNorth()
        {
            BotAI.TurnAction = TurnAction.Move.North();
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 1);
            Verify.That(result).Is($"{Bot.Name} is destroyed by {Attacker.Name}.");
        }
    }
}