using System.ComponentModel.Composition.Hosting;
using NUnit.Framework;

namespace CodingArena.Game.Tests
{
    public class TestFixture<T> where T: class
    {
        [SetUp]
        public virtual void SetUp()
        {
            Container = CompositionContainerFactory.Create();
            CreateSUT();
        }

        public CompositionContainer Container { get; private set; }

        protected virtual void CreateSUT() => SUT = Get<T>();

        public TValue Get<TValue>() => Container.GetExportedValue<TValue>();

        public T SUT { get; private set; }
    }
}