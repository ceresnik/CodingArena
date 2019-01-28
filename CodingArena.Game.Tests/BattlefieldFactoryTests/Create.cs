using CodingArena.Player.Battlefield;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BattlefieldFactoryTests
{
    internal class Create : TestFixture
    {
        private IBattlefield Battlefield { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = SUT.Create();
        }

        [Test]
        public void NotNull() => Battlefield.Should().NotBeNull();
    }
}