using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.GameEngineTests
{
    internal class Create : TestFixture
    {
        [Test]
        public void Match_NotNull() => SUT.Match.Should().NotBeNull();
    }
}