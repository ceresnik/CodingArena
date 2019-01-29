using System;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.DefaultSettingsTests
{
    internal class DefaultValues : TestFixture
    {
        [Test]
        public void BattlefieldSize()
        {
            SUT.BattlefieldWidth.Should().Be(100);
            SUT.BattlefieldHeight.Should().Be(100);
        }

        [Test]
        public void NextRoundDelay() => 
            SUT.NextRoundDelay.Should().Be(new TimeSpan(0, 0, 0, 10));
    }
}