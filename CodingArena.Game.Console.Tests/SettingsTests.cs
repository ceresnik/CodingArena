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
        public void BattlefieldWidth() => Settings.BattlefieldWidth.Should().Be(100);

        [Test]
        public void BattlefieldHeight() => Settings.BattlefieldHeight.Should().Be(100);

        [Test]
        public void MaxRounds() => Settings.MaxRounds.Should().Be(100);

        [Test]
        public void MaxTurns() => Settings.MaxTurns.Should().Be(120);

        [Test]
        public void NextRoundDelay() => Settings.NextRoundDelay.Should().Be(TimeSpan.FromSeconds(60));

        [Test]
        public void NextTurnActionDelay() => Settings.NextTurnActionDelay.Should().Be(TimeSpan.FromMilliseconds(500));
    }
}