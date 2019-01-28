using CodingArena.Game.Console;
using NUnit.Framework;

namespace CodingArena.Game.Tests.MatchTests
{
    internal class TestFixture : TestFixture<IMatch>
    {
        protected Doubles.Output Output { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Output = Get<IOutput>() as Doubles.Output;
        }
    }
}