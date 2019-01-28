using System.Collections.Generic;
using CodingArena.Game.Console;
using CodingArena.Game.Tests.Doubles;
using NUnit.Framework;

namespace CodingArena.Game.Tests.TurnTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected Turn Turn { get; private set; }
        protected List<Bot> Bots { get; private set; }
        protected Battlefield Battlefield { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Bots = new List<Bot>();
            var settings = new TestSettings();
            Battlefield = new Battlefield(settings);
            Turn = new Turn(0, Bots, Battlefield);
        }
    }
}