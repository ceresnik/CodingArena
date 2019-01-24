using System;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class TestFixture : TestFixture<IMatch>
    {
        protected Match Match { get; private set; }
        protected Doubles.Output Output { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Output = Get<IOutput>() as Doubles.Output;
            Match = new Match(Output, new GameConfiguration {TurnActionDelay = TimeSpan.MinValue});
        }
    }
}