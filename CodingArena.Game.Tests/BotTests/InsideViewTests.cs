using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class InsideViewTests : TestFixture
    {
        [Test]
        public void Health_Maximum() => Bot.InsideView.Health.Maximum.Should().Be(Bot.MaxHP);

        [Test]
        public void Health_Actual()
        {
            Bot.TakeDamage(Bot.MaxSP + 1);
            Bot.InsideView.Health.Actual.Should().Be(Bot.MaxHP - 1);
        }

        [Test]
        public void Health_Percent()
        {
            Bot.TakeDamage(Bot.MaxSP + Bot.MaxHP / 2);
            Bot.InsideView.Health.Percent.Should().Be(50);
        }

        [Test]
        public void Shield_Maximum() => Bot.InsideView.Shield.Maximum.Should().Be(Bot.MaxSP);

        [Test]
        public void Shield_Actual()
        {
            Bot.TakeDamage(1);
            Bot.InsideView.Shield.Actual.Should().Be(Bot.MaxSP - 1);
        }

        [Test]
        public void Shield_Percent()
        {
            Bot.TakeDamage(Bot.MaxSP / 2);
            Bot.InsideView.Shield.Percent.Should().Be(50);
        }

        [Test]
        public void Energy_Maximum() => Bot.InsideView.Energy.Maximum.Should().Be(Bot.MaxEP);

        [Test]
        public void Energy_Actual()
        {
            Bot.DrainEnergy(1);
            Bot.InsideView.Energy.Actual.Should().Be(Bot.MaxEP - 1);
        }

        [Test]
        public void Energy_Percent()
        {
            Bot.DrainEnergy(Bot.MaxEP / 2);
            Bot.InsideView.Energy.Percent.Should().Be(50);
        }
    }
}