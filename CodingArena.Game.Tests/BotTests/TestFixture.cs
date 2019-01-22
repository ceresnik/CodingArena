using System;
using CodingArena.Player.Implement;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected Bot Bot { get; private set; }
        protected IBotAI BotAI { get; private set; }
        protected Battlefield Battlefield { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            BotAI = new BotAIStub();
            Battlefield = new Battlefield(100, 100);
            Bot = new Bot(Console.Out, BotAI, Battlefield);
        }
    }
}