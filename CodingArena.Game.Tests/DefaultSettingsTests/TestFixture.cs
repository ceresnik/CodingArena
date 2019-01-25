using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.DefaultSettingsTests
{
    [TestFixture]
    public class TestFixture
    {
        [SetUp]
        public virtual void SetUp() => SUT = new DefaultSettings();

        public ISettings SUT { get; set; }
    }

    internal class DefaultValues : TestFixture
    {
        [Test]
        public void BattlefieldSize()
        {
            SUT.BattlefieldSize.Should().NotBeNull();
            SUT.BattlefieldSize.Width.Should().Be(100);
            SUT.BattlefieldSize.Height.Should().Be(100);
        }
    }
}