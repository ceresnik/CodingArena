using CodingArena.Game.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.BattlefieldFactoryTests
{
    internal class Create : TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = BattlefieldFactory.Create();
        }

        private IBattlefield Battlefield { get; set; }

        [Test]
        public void Battlefield_NotNull() => Battlefield.Should().NotBeNull();
    }
}