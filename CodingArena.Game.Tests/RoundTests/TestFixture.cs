using System.Collections.Generic;
using CodingArena.Game.Console;
using CodingArena.Game.Tests.Doubles;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected IRound Round { get; private set; }
        protected IList<Bot> Bots { get; private set; }
        protected Battlefield Battlefield { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            var settings = new TestSettings();
            Round = new Round(new Doubles.Output(), settings);
            Bots = new List<Bot>();
            Battlefield = new Battlefield(settings);
        }
    }
}