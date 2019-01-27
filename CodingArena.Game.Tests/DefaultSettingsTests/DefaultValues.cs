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
            SUT.BattlefieldSize.Should().NotBeNull();
            SUT.BattlefieldSize.Width.Should().Be(100);
            SUT.BattlefieldSize.Height.Should().Be(100);
        }

        [Test]
        public void NextRoundDelay() => 
            SUT.NextRoundDelay.Should().Be(new TimeSpan(0, 0, 0, 10));
    }
}