using System.ComponentModel.Composition.Hosting;

namespace CodingArena.Game.Tests
{
    internal class TestFixtureBase
    {
        public virtual void SetUp()
        {
            Container = CompositionContainerFactory.Create();
        }

        protected CompositionContainer Container { get; private set; }

        protected TValue Get<TValue>() => Container.GetExportedValue<TValue>();
    }
}