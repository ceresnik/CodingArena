using CodingArena.Game.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.Factories.TurnFactoryTests
{
    internal class Create : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Turn = TurnFactory.Create(1);
        }

        private ITurn Turn { get; set; }

        [Test]
        public void Turn_NotNull() => Turn.Should().NotBeNull();
    }
}