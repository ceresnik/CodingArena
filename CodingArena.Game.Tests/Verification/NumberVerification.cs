using FluentAssertions;

namespace CodingArena.Game.Tests.Verification
{
    internal class NumberVerification
    {
        private int Number { get; }

        public NumberVerification(int number)
        {
            Number = number;
        }

        public void Is(int expectedNumber) => Number.Should().Be(expectedNumber);
    }
}