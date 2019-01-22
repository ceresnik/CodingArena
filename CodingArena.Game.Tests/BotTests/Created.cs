using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class Created : TestFixture
    {
        [Test]
        public void Name() => Bot.Name.Should().Be(BotAI.BotName);

        [Test]
        public void Health() => Bot.Health.Should().Be(100);

        [Test]
        public void Damage() => Bot.Damage.Should().Be(0);

        [Test]
        public void Shield() => Bot.Shield.Should().Be(100);

        [Test]
        public void Energy() => Bot.Energy.Should().Be(100);

        [Test]
        public void MaxHP() => Bot.MaxHP.Should().Be(1000);

        [Test]
        public void HP() => Bot.HP.Should().Be(Bot.MaxHP);

        [Test]
        public void MaxSP() => Bot.MaxSP.Should().Be(1000);

        [Test]
        public void SP() => Bot.SP.Should().Be(Bot.MaxSP);

        [Test]
        public void MaxEP() => Bot.MaxEP.Should().Be(1000);

        [Test]
        public void EP() => Bot.EP.Should().Be(Bot.MaxEP);

        [Test]
        public void Position() => Bot.Position.Should().BeNull();
    }
}