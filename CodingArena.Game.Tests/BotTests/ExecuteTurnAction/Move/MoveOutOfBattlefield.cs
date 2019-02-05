using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveOutOfBattlefield : TestFixture
    {
        [Test]
        public void MoveWestOutOfBattlefield_Explode()
        {
            BotAI.TurnAction = TurnAction.Move.West();
            Bot.PositionTo(0, 0);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(0, 0);
            Verify.That(Bot.HP).Is(0);
            Verify.That(IsExplodedEventRaised).IsTrue();
        }

        [Test]
        public void MoveSouthOutOfBattlefield_Explode()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            Bot.PositionTo(0, 0);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(0, 0);
            Verify.That(Bot.HP).Is(0);
            Verify.That(IsExplodedEventRaised).IsTrue();
        }

        [Test]
        public void MoveEastOutOfBattlefield_Explode()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            Bot.PositionTo(Battlefield.Width - 1, 0);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(Battlefield.Width - 1, 0);
            Verify.That(Bot.HP).Is(0);
            Verify.That(IsExplodedEventRaised).IsTrue();
        }

        [Test]
        public void MoveNorthOutOfBattlefield_Explode()
        {
            BotAI.TurnAction = TurnAction.Move.North();
            Bot.PositionTo(0, Battlefield.Height - 1);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.Position).Is(0, Battlefield.Height - 1);
            Verify.That(Bot.HP).Is(0);
            Verify.That(IsExplodedEventRaised).IsTrue();
        }
    }
}