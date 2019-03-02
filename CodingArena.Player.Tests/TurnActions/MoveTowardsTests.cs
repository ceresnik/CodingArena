using CodingArena.Player.Battlefield;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace CodingArena.Player.Tests.TurnActions
{
    internal class MoveTowardsTests
    {
        private IBattlefieldPlace NewPlace { get; set; }
        private MoveTowards TurnAction { get; set; }

        [SetUp]
        public void SetUp()
        {
            NewPlace = new Mock<IBattlefieldPlace>().Object;
            TurnAction = Player.TurnActions.TurnAction.Move.Towards(NewPlace) as MoveTowards;
        }

        [Test]
        public void NotNull() => TurnAction.Should().NotBeNull();

        [Test]
        public void NullPlace_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                Player.TurnActions.TurnAction.Move.Towards(null));

        [Test]
        public void EnergyCost() => TurnAction.EnergyCost.Should().Be(2);

        [Test]
        public void Place() => TurnAction.Place.Should().Be(NewPlace);
    }
}