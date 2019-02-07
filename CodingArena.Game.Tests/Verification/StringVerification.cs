using FluentAssertions;

namespace CodingArena.Game.Tests.Verification
{
    internal class StringVerification
    {
        private string Text { get; }

        public StringVerification(string text)
        {
            Text = text;
        }

        public void Is(string expectedText) => Text.Should().Be(expectedText);
    }
}