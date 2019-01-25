using System;
using CodingArena.Player.Battlefield;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Player.Tests.BattlefieldTests
{
    internal class SizeTests
    {
        [Test]
        public void Width_Positive() => new Size(10, 12).Width.Should().Be(10);

        [Test]
        public void Height_Positive() => new Size(10, 12).Height.Should().Be(12);

        [Test]
        public void Height_Zero() => Assert.Throws<ArgumentException>(() => new Size(10, 0));

        [Test]
        public void Width_Zero() => Assert.Throws<ArgumentException>(() => new Size(0, 34));

        [Test]
        public void Width_Negative() => Assert.Throws<ArgumentException>(() => new Size(-1, 3));

        [Test]
        public void Height_Negative() => Assert.Throws<ArgumentException>(() => new Size(76, -1));

        [Test]
        public void Equality() => new Size(1, 2).Should().Be(new Size(1, 2));

        [Test]
        public void Format() => new Size(1, 2).ToString().Should().Be("[Width: 1, Height: 2]");
    }
}