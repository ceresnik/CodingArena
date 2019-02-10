using CodingArena.Game.Entities;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class CannotMoveOnOccupiedPlace : TestFixture
    {
        private IBattleBot Enemy { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Bot.PositionTo(Battlefield, 0, 0);
            BotAI.TurnAction = TurnAction.Move.East();
            Enemy = BotWorkshop.Create(TestBotAI.Idle);
            Enemy.PositionTo(Battlefield, 1, 0);
            Bot.ExecuteTurnAction(new List<IBattleBot> { Enemy });
        }

        [Test]
        public void Position_NotChanged() =>
            Verify.That(Bot.Position).Is(0, 0);

        [Test]
        public void BotAction_IsUpdated() =>
            Verify.That(Bot.Action).Is($"{Bot.Name} cannot move East, place is occupied.");
    }
}