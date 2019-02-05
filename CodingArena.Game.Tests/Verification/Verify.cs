using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Tests.Verification
{
    internal static class Verify
    {
        public static BooleanVerification That(bool condition) => new BooleanVerification(condition);
        public static NumberVerification That(int number) => new NumberVerification(number);
        public static BattlefieldPlaceVerification That(IBattlefieldPlace place) => new BattlefieldPlaceVerification(place);
    }
}