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
            Round = Get<IRoundFactory>().Create(1);
            BotFactory = Get<IBotFactory>() as BotFactory;
            BotWorkshop = Get<IBotWorkshop>();
        }

        protected IRound Round { get; private set; }
        protected BotFactory BotFactory { get; private set; }
        protected IBotWorkshop BotWorkshop { get; private set; }
    }
}