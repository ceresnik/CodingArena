using System.Collections.Generic;
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
            Battlefield = new Battlefield(100, 100);
            Settings = container.GetExportedValue<ISettings>();
            Bot = new Bot(new Doubles.Output(), BotAI, Battlefield, Settings);
            Enemies = new List<Bot>();
        }
    }
}