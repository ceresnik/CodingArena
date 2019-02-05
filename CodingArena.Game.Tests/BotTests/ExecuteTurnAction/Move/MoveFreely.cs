using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveFreely : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Bot.PositionTo(1, 1);
        }

        [Test]
        public void MoveEast()
        {
            BotAI.TurnAction = TurnAction.Move.East();            
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(2, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveWest()
        {
            BotAI.TurnAction = TurnAction.Move.West();
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(0, 1);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveSouth()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(1, 0);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveNorth()
        {
            BotAI.TurnAction = TurnAction.Move.North();
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(1, 2);
            Verify.That(Bot.EP).Is(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }
    }
}