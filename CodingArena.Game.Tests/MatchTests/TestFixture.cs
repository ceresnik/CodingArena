using System;
using CodingArena.Game.Tests.SystemTests;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    public class TestFixture
    {
        protected Match Match { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Match = new Match(new TestOutput(), new GameConfiguration {TurnActionDelay = TimeSpan.MinValue});
        }
    }
}