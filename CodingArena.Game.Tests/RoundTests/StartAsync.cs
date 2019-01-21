using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodingArena.Game.Tests.RoundTests
{
    internal class StartAsync : TestFixture
    {
        [Test]
        public void StartAsync_NullBots_ArgumentNullException() => 
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Round.StartAsync(null, new Battlefield(1000, 1000)));

        [Test]
        public void StartAsync_NullBattlefield_ArgumentNullException() =>
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Round.StartAsync(new List<Automata>(), null));
    }
}