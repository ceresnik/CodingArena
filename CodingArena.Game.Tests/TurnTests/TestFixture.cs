using CodingArena.Game.Entities;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;

namespace CodingArena.Game.Tests.TurnTests
{
    internal class TestFixture : TestFixtureBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
            BotWorkshop = Get<IBotWorkshop>();
            TurnFactory = Get<ITurnFactory>();
            Turn = TurnFactory.Create(1);
            Settings = Get<ISettings>();
            AttackerBot = BotWorkshop.Create(TestBotAI.AttackFirstEnemy);
            IdleBot = BotWorkshop.Create(TestBotAI.Idle);
        }

        protected IBattlefield Battlefield { get; private set; }

        protected IBotWorkshop BotWorkshop { get; private set; }

        protected ITurnFactory TurnFactory { get; private set; }

        protected ISettings Settings { get; private set; }

        protected ITurn Turn { get; private set; }

        protected IBattleBot AttackerBot { get; private set; }

        protected IBattleBot IdleBot { get; private set; }
    }
}