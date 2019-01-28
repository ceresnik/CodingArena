using System.Collections.Generic;
using CodingArena.Game.Console;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected ISettings Settings { get; private set; }
        protected Bot Bot { get; private set; }
        protected BotAIStub BotAI { get; private set; }
        protected Battlefield Battlefield { get; private set; }
        protected List<Bot> Enemies { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            var container = CompositionContainerFactory.Create();
            BotAI = new BotAIStub();
            Settings = container.GetExportedValue<ISettings>();
            Battlefield = new Battlefield(Settings);
            Bot = new Bot(new Doubles.Output(), BotAI, Battlefield, Settings);
            Enemies = new List<Bot>();
        }
    }
}