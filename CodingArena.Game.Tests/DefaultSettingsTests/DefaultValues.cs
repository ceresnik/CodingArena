using FluentAssertions;
using NUnit.Framework;
using System;

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
            SUT.NextRoundDelay.Should().Be(TimeSpan.FromMinutes(1));
    }
}