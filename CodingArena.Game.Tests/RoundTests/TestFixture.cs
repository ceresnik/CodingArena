using CodingArena.Game.Factories;
using CodingArena.Game.Tests.Doubles;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class TestFixture : TestFixtureBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Round = Get<IRoundFactory>().Create();
            BotFactory = Get<IBotFactory>() as BotFactory;
            BotWorkshop = Get<IBotWorkshop>();
            Battlefield = Get<IBattlefieldFactory>().Create();
        }

        protected IRound Round { get; private set; }
        protected BotFactory BotFactory { get; private set; }
        protected IBotWorkshop BotWorkshop { get; private set; }
        protected IBattlefield Battlefield { get; private set; }
    }
}