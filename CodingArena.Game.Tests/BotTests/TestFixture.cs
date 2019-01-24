using System;
using System.Collections.Generic;
using CodingArena.Game.Tests.SystemTests;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected Bot Bot { get; private set; }
        protected BotAIStub BotAI { get; private set; }
        protected Battlefield Battlefield { get; private set; }
        protected List<Bot> Enemies { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            BotAI = new BotAIStub();
            Battlefield = new Battlefield(100, 100);
            Bot = new Bot(new TestOutput(), BotAI, Battlefield,
                new GameConfiguration {TurnActionDelay = TimeSpan.FromMilliseconds(0)});
            Enemies = new List<Bot>();
        }
    }
}