using System;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Console.Tests
{
    internal class SettingsTests
    {
        private Settings Settings { get; set; }

        [SetUp]
        public void SetUp() => Settings = new Settings();

        [Test]
        public void BattlefieldWidth() => Settings.BattlefieldWidth.Should().Be(50);

        [Test]
        public void BattlefieldHeight() => Settings.BattlefieldHeight.Should().Be(50);

        [Test]
        public void MaxRounds() => Settings.MaxRounds.Should().Be(100);

        [Test]
        public void MaxTurns() => Settings.MaxTurns.Should().Be(120);

        [Test]
        public void NextRoundDelay() => Settings.NextRoundDelay.Should().Be(TimeSpan.FromSeconds(60));

        [Test]
        public void NextTurnActionDelay() => Settings.NextTurnDelay.Should().Be(TimeSpan.FromMilliseconds(500));

        [Test]
        public void MaxHP() => Settings.MaxHP.Should().Be(500);

        [Test]
        public void MaxSP() => Settings.MaxSP.Should().Be(200);

        [Test]
        public void MaxEP() => Settings.MaxEP.Should().Be(500);
    }
}