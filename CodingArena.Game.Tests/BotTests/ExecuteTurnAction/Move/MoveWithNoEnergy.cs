using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveWithNoEnergy : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Bot.PositionTo(1, 1);
            Bot.DrainEnergy(Bot.EP);
        }

        [Test]
        public void MoveEast()
        {
            BotAI.TurnAction = TurnAction.Move.East();            
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 1);
        }

        [Test]
        public void MoveWest()
        {
            BotAI.TurnAction = TurnAction.Move.West();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 1);
        }

        [Test]
        public void MoveSouth()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 1);
        }

        [Test]
        public void MoveNorth()
        {
            BotAI.TurnAction = TurnAction.Move.North();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 1);
        }
    }
}