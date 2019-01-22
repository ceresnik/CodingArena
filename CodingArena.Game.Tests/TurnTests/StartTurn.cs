﻿using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class StartTurnWithNoBots : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            NewTurn = Turn.StartTurn();
        }

        protected Turn NewTurn { get; set; }

        [Test]
        public void IncreaseTurnNumber() => NewTurn.Number.Should().Be(Turn.Number + 1);
    }
}