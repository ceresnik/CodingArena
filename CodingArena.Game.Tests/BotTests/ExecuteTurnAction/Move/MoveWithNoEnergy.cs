using CodingArena.Game.Factories;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveWithNoEnergy : TestFixture
    {
        [Test]
        public void MoveEast()
        {
            var botAI = new TestBotAI(TurnAction.Move.East());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.DrainEnergy(bot.EP);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(1);
        }

        [Test]
        public void MoveWest()
        {
            var botAI = new TestBotAI(TurnAction.Move.West());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.DrainEnergy(bot.EP);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(1);
        }

        [Test]
        public void MoveSouth()
        {
            var botAI = new TestBotAI(TurnAction.Move.South());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.DrainEnergy(bot.EP);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(1);
        }

        [Test]
        public void MoveNorth()
        {
            var botAI = new TestBotAI(TurnAction.Move.North());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.DrainEnergy(bot.EP);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(1);
        }
    }
}