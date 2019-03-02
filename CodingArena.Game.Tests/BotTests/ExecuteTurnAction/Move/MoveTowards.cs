using CodingArena.Game.Entities;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveTowards : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Bot.PositionTo(Battlefield, 1, 1);
        }

        [Test]
        public void NearEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.Towards(Battlefield[2, 1]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(2, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void TwoPlacesEastEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.Towards(Battlefield[3, 1]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(2, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void SlightlyDiagonalEastEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.Towards(Battlefield[3, 2]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(2, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void OnePlaceNorthToEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.Towards(Battlefield[1, 2]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 2);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void AtSamePosition()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            BotAI.TurnAction = TurnAction.Move.Towards(Battlefield[0, 0]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Action).Is($"{Bot.Name} stays at current position.");
            Verify.That(Bot.Position).Is(0, 0);
            Verify.That(Bot.EP).Is(Bot.MaxEP);
        }
    }
}