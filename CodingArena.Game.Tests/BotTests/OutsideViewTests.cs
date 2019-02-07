using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests
{
    internal class OutsideViewTests : TestFixture
    {
        [Test]
        public void Health_Maximum() => Bot.OutsideView.Health.Maximum.Should().Be(Bot.MaxHP);

        [Test]
        public void Health_Actual()
        {
            Bot.TakeDamage(Bot.MaxSP + 1);
            Bot.OutsideView.Health.Actual.Should().Be(Bot.MaxHP - 1);
        }

        [Test]
        public void Health_Percent()
        {
            Bot.TakeDamage(Bot.MaxSP + Bot.MaxHP / 2);
            Bot.OutsideView.Health.Percent.Should().Be(50);
        }

        [Test]
        public void Shield_Maximum() => Bot.OutsideView.Shield.Maximum.Should().Be(Bot.MaxSP);

        [Test]
        public void Shield_Actual()
        {
            Bot.TakeDamage(1);
            Bot.OutsideView.Shield.Actual.Should().Be(Bot.MaxSP - 1);
        }

        [Test]
        public void Shield_Percent()
        {
            Bot.TakeDamage(Bot.MaxSP / 2);
            Bot.OutsideView.Shield.Percent.Should().Be(50);
        }
    }
}