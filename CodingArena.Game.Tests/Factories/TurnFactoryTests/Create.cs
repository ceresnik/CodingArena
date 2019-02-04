using CodingArena.Game.Factories;
using CodingArena.Player.Battlefield;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.Factories.TurnFactoryTests
{
    internal class Create : TestFixture
    {
        private ITurn Turn { get; set; }

        private int Number { get; set; }

        private IBattlefieldView BattlefieldView { get; set; }

        public override void SetUp()
        {
            base.SetUp();
            BattlefieldView = Get<IBattlefieldFactory>().Create();
            Turn = SUT.Create(Number, new List<Bot>(), BattlefieldView);
        }

        [Test]
        public void Turn_NotNull() => Turn.Should().NotBeNull();

        [Test]
        public void Turn_Controller_NotNull() => Turn.Controller.Should().NotBeNull();

        [Test]
        public void Turn_Notifier_NotNull() => Turn.Notifier.Should().NotBeNull();
    }
}