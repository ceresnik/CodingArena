using CodingArena.Game.Factories;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction.Move
{
    internal class MoveOutOfBattlefield : TestFixture
    {
        [Test]
        public void MoveWestOutOfBattlefield_Explode()
        {
            var botAI = new TestBotAI(TurnAction.Move.West());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(0, 0);
            bool isExploded = false;
            bot.Exploded += (sender, args) => isExploded = true;
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(0);
            bot.Position.Y.Should().Be(0);
            bot.HP.Should().Be(0);
            isExploded.Should().BeTrue();
        }

        [Test]
        public void MoveSouthOutOfBattlefield_Explode()
        {
            var botAI = new TestBotAI(TurnAction.Move.South());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(0, 0);
            bool isExploded = false;
            bot.Exploded += (sender, args) => isExploded = true;
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(0);
            bot.Position.Y.Should().Be(0);
            bot.HP.Should().Be(0);
            isExploded.Should().BeTrue();
        }

        [Test]
        public void MoveEastOutOfBattlefield_Explode()
        {
            var botAI = new TestBotAI(TurnAction.Move.South());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(Battlefield.Width - 1, 0);
            bool isExploded = false;
            bot.Exploded += (sender, args) => isExploded = true;
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(Battlefield.Width - 1);
            bot.Position.Y.Should().Be(0);
            bot.HP.Should().Be(0);
            isExploded.Should().BeTrue();
        }

        [Test]
        public void MoveNorthOutOfBattlefield_Explode()
        {
            var botAI = new TestBotAI(TurnAction.Move.North());
            var bot = Get<IBotFactory>().Create(botAI, Battlefield);
            bot.PositionTo(0, Battlefield.Height - 1);
            bool isExploded = false;
            bot.Exploded += (sender, args) => isExploded = true;
            bot.ExecuteTurnAction();
            bot.Position.X.Should().Be(0);
            bot.Position.Y.Should().Be(Battlefield.Height - 1);
            bot.HP.Should().Be(0);
            isExploded.Should().BeTrue();
        }
    }
}