using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class TestFixture : TestFixtureBase
    {
        protected TestBotAI BotAI { get; private set; }
        protected IBattlefield Battlefield { get; private set; }
        protected IBattleBot Bot { get; private set; }
        protected bool IsExplodedEventRaised { get; private set; }
        protected int RechargeAmount { get; set; }
        protected int EnergyCost { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Battlefield = Get<IBattlefieldFactory>().Create();
            BotAI = new TestBotAI();
            Bot = Get<IBotWorkshop>().Create(BotAI);
            IsExplodedEventRaised = false;
            Bot.Exploded += (sender, args) => IsExplodedEventRaised = true;
        }
    }
}