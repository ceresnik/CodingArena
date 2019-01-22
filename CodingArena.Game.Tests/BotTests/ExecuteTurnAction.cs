using System;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class ExecuteTurnAction : TestFixture
    {
        [Test]
        public void NullBots_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(
                () => Bot.ExecuteTurnAction(null));

        [Test]
        public void Move_West_Successful()
        {
            int x = 1;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.West();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x - 1, y]);
        }

        [Test]
        public void Move_East_Successful()
        {
            int x = 0;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.East();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x + 1, y]);
        }

        [Test]
        public void Move_North_Successful()
        {
            int x = 0;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.North();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y + 1]);
        }

        [Test]
        public void Move_South_Successful()
        {
            int x = 0;
            int y = 1;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.South();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y - 1]);
        }

        [Test]
        public void Move_West_OutOfBoundary()
        {
            int x = 0;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.West();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y]);
        }

        [Test]
        public void Move_South_OutOfBoundary()
        {
            int x = 0;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.South();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y]);
        }

        [Test]
        public void Move_North_OutOfBoundary()
        {
            int x = 0;
            int y = Battlefield.Size.Height - 1;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.North();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y]);
        }

        [Test]
        public void Move_East_OutOfBoundary()
        {
            int x = Battlefield.Size.Width - 1;
            int y = 0;
            Battlefield[x, y] = new BattlefieldPlace(x, y, Bot);
            BotAI.Action = TurnAction.Move.East();
            Bot.ExecuteTurnAction(Enemies);
            Bot.Position.Should().Be(Battlefield[x, y]);
        }
    }
}