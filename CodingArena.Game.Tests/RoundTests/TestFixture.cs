using System;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected Round Round { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Round = new Round(Console.Out);
        }
    }
}