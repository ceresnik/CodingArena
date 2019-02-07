using CodingArena.Game.Entities;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class DistanceToTests : TestFixtureBase
    {
        private IBattleBot Bot1 { get; set; }
        private IBattleBot Bot2 { get; set; }
        private IBattlefield Battlefield { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
            Bot1 = Get<IBotWorkshop>().Create(TestBotAI.Idle);
            Bot2 = Get<IBotWorkshop>().Create(TestBotAI.Idle);
        }

        [Test]
        public void OnePlace()
        {
            Bot1.PositionTo(Battlefield, 0, 0);
            Bot2.PositionTo(Battlefield, 1, 0);
            Bot1.DistanceTo(Bot2.InsideView).Should().Be(1);
            Bot1.DistanceTo(Bot2.OutsideView).Should().Be(1);
        }
    }
}