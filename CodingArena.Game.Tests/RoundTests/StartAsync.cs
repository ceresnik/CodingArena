using System;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    [TestFixture]
    internal class StartAsync : TestFixture
    {
        [Test]
        public void NullBots_ThrowsArgumentNullException() =>
            Assert.ThrowsAsync<ArgumentNullException>(
                () => Round.StartAsync(null, Battlefield));

        [Test]
        public void NullBattlefield_ThrowsArgumentNullException() =>
            Assert.ThrowsAsync<ArgumentNullException>(
                () => Round.StartAsync(Bots, null));
    }
}