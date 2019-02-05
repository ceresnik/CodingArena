using System.Collections.Generic;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class Attack : TestFixture
    {
        private IBattleBot Enemy { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Enemy = Get<IBotFactory>().Create(new IdleBotAI(), Battlefield);
            var turnAction = TurnAction.Attack(Enemy.OutsideView);
            BotAI.TurnAction = turnAction;
            EnergyCost = BotAI.TurnAction.EnergyCost;
        }

        [Test]
        public void OutOfRange()
        {
            Bot.PositionTo(0, 0);
            Enemy.PositionTo(10, 0);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(Enemy.HP).Is(Enemy.MaxHP);
            Verify.That(Enemy.SP).Is(Enemy.MaxSP);
            Verify.That(Enemy.EP).Is(Enemy.MaxEP);
        }
    }
}