using CodingArena.Game.Entities;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.Doubles;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Match = Get<IMatchFactory>().Create();
            BotFactory = Get<IBotFactory>() as BotFactory;
            BotWorkshop = Get<IBotWorkshop>();
        }

        protected IMatch Match { get; private set; }
        protected BotFactory BotFactory { get; private set; }
        protected IBotWorkshop BotWorkshop { get; private set; }
    }
}