using FluentAssertions;

namespace CodingArena.Game.Tests.Verification
{
    internal class BooleanVerification
    {
        private bool Condition { get; }

        public BooleanVerification(bool condition)
        {
            Condition = condition;
        }

        public void IsTrue() => Condition.Should().BeTrue();
        public void IsFalse() => Condition.Should().BeFalse();
    }
}