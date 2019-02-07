using System;
using CodingArena.Player.TurnActions;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Player.Tests.TurnActions
{
    internal class RechargeShieldTests
    {
        [Test]
        public void NotNull() => TurnAction.Recharge.Shield(1).Should().NotBeNull();

        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(10,10)]
        [TestCase(100,100)]
        [TestCase(1000,1000)]
        public void PositiveAmount(int amount, int energyCost) => 
            TurnAction.Recharge.Shield(amount).EnergyCost.Should().Be(energyCost);

        [Test]
        public void NegativeAmount() => 
            Assert.Throws<ArgumentOutOfRangeException>(() => TurnAction.Recharge.Shield(-1));
    }
}