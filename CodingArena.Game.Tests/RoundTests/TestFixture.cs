using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected Round Round { get; private set; }
        protected IList<Bot> Bots { get; private set; }
        protected Battlefield Battlefield { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Round = new Round(Console.Out);
            Bots = new List<Bot>();
            Battlefield = new Battlefield(100, 100);
        }
    }
}