using NUnit.Framework;
using System.ComponentModel.Composition.Hosting;

namespace CodingArena.Game.Tests
{
    internal class TestFixture
    {
        [SetUp]
        public virtual void SetUp()
        {
            Container = CompositionContainerFactory.Create();
        }

        protected CompositionContainer Container { get; private set; }

        protected TValue Get<TValue>() => Container.GetExportedValue<TValue>();
    }

    internal class TestFixture<T> : TestFixture where T : class
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            CreateSUT();
        }

        protected virtual void CreateSUT() => SUT = Get<T>();

        public T SUT { get; private set; }
    }
}