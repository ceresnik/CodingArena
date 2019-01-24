using System.ComponentModel.Composition.Hosting;
using FluentAssertions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.CompositionContainerTests
{
    [TestFixture]
    internal class TestFixture
    {
        protected CompositionContainer Container { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(GameEngine).Assembly));
            Container = new CompositionContainer(catalog);
        }

        [Test]
        public void CompositionContainer() => Container.Should().NotBeNull();
    }
}