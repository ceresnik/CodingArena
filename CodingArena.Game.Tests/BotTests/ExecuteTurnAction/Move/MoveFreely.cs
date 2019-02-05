﻿using CodingArena.Player.TurnActions;
using FluentAssertions;
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
            Bot.Position.Is(2, 1);
            Bot.EP.Should().Be(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveWest()
        {
            BotAI.TurnAction = TurnAction.Move.West();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(0, 1);
            Bot.EP.Should().Be(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveSouth()
        {
            BotAI.TurnAction = TurnAction.Move.South();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 0);
            Bot.EP.Should().Be(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }

        [Test]
        public void MoveNorth()
        {
            BotAI.TurnAction = TurnAction.Move.North();
            Bot.ExecuteTurnAction();
            Bot.Position.Is(1, 2);
            Bot.EP.Should().Be(Bot.MaxEP - BotAI.TurnAction.EnergyCost);
        }
    }
}