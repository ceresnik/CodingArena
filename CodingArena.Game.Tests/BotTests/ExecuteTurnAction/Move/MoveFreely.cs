using CodingArena.Game.Factories;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveFreely : TestFixture
    {
        [Test]
        public void MoveEast()
        {
            var turnAction = TurnAction.Move.East();
            var botAI = new TestBotAI(turnAction);
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(2);
            bot.Position.Y.Should().Be(1);
            bot.EP.Should().Be(bot.MaxEP - turnAction.EnergyCost);

        }

        [Test]
        public void MoveWest()
        {
            var turnAction = TurnAction.Move.West();
            var botAI = new TestBotAI(turnAction);
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(0);
            bot.Position.Y.Should().Be(1);
            bot.EP.Should().Be(bot.MaxEP - turnAction.EnergyCost);
        }

        [Test]
        public void MoveSouth()
        {
            var turnAction = TurnAction.Move.South();
            var botAI = new TestBotAI(turnAction);
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(0);
            bot.EP.Should().Be(bot.MaxEP - turnAction.EnergyCost);
        }

        [Test]
        public void MoveNorth()
        {
            var turnAction = TurnAction.Move.North();
            var botAI = new TestBotAI(turnAction);
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(1, 1);
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(1);
            bot.Position.Y.Should().Be(2);
            bot.EP.Should().Be(bot.MaxEP - turnAction.EnergyCost);
        }
    }
}