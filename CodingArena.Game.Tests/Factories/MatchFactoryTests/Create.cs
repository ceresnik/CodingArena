using CodingArena.Game.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.MatchFactoryTests
{
    internal class Create : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Match = MatchFactory.Create();
        }

        private IMatch Match { get; set; }

        [Test]
        public void Match_NotNull() => Match.Should().NotBeNull();
    }
}