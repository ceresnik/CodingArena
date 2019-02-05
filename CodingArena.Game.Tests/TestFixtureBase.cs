using System.ComponentModel.Composition.Hosting;
using NUnit.Framework;

namespace CodingArena.Game.Tests
{
    internal class TestFixtureBase
    {
        [SetUp]
        public virtual void SetUp()
        {
            Container = CompositionContainerFactory.Create();
        }

        protected CompositionContainer Container { get; private set; }

        protected TValue Get<TValue>() => Container.GetExportedValue<TValue>();
    }
}