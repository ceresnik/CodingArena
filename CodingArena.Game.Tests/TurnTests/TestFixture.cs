﻿using CodingArena.Game.Factories;

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
            Settings = Get<ISettings>();
        }

        protected IBattlefield Battlefield { get; private set; }
        protected IBotWorkshop BotWorkshop { get; private set; }
        protected ITurnFactory TurnFactory { get; private set; }
        protected ISettings Settings { get; private set; }
    }
}