using CodingArena.Player.Battlefield;
using FluentAssertions;

namespace CodingArena.Game.Tests
{
    internal static class Extensions
    {
        public static void Is(this IBattlefieldPlace place, int x, int y)
        {
            place.X.Should().Be(x);
            place.Y.Should().Be(y);
        }
    }
}