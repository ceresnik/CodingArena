using System.Collections.Generic;
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
            Battlefield = new Battlefield(100, 100);
            Turn = new Turn(0, Bots, Battlefield);
        }
    }
}