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
}