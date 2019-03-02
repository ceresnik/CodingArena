using CodingArena.Game.Entities;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveAwayFrom : TestFixture
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
            BotAI.TurnAction = TurnAction.Move.AwayFrom(Battlefield[2, 1]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(0, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void TwoPlacesEastEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.AwayFrom(Battlefield[3, 1]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(0, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void SlightlyDiagonalEastEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.AwayFrom(Battlefield[3, 2]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(0, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void OnePlaceNorthToEmptyPlace()
        {
            BotAI.TurnAction = TurnAction.Move.AwayFrom(Battlefield[1, 2]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 0);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void AtSamePosition()
        {
            Bot.PositionTo(Battlefield, 0, 0);
            BotAI.TurnAction = TurnAction.Move.AwayFrom(Battlefield[0, 0]);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(1, 0);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }
    }
}