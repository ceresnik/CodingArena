using CodingArena.Player.Battlefield;
using FluentAssertions;

namespace CodingArena.Game.Tests.Verification
{
    internal static class Verify
    {
        public static NumberVerification That(int number) => new NumberVerification(number);
        public static BattlefieldPlaceVerification That(IBattlefieldPlace place) => new BattlefieldPlaceVerification(place);
    }

    internal class NumberVerification
    {
        private int Number { get; }

        public NumberVerification(int number)
        {
            Number = number;
        }

        public void Is(int expectedNumber) => Number.Should().Be(expectedNumber);
    }

    internal class BattlefieldPlaceVerification
    {
        private IBattlefieldPlace Place { get; }

        public BattlefieldPlaceVerification(IBattlefieldPlace place)
        {
            Place = place;
        }

        public void Is(int x, int y)
        {
            Place.X.Should().Be(x);
            Place.Y.Should().Be(y);
        }
    }
}