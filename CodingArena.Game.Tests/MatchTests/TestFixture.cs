using System;
using CodingArena.Game.Tests.SystemTests;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class TestFixture
    {
        protected Match Match { get; private set; }
        protected TestOutput Output { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Output = new TestOutput();
            Match = new Match(Output, new GameConfiguration {TurnActionDelay = TimeSpan.MinValue});
        }
    }
}