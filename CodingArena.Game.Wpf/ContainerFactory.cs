using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    internal class ContainerFactory
    {
        public static CompositionContainer Create() =>
            new CompositionContainer(
                new AggregateCatalog(
                    new AssemblyCatalog(Assembly.Load(typeof(IGame).Assembly.ToString())),
                    new AssemblyCatalog(Assembly.Load(typeof(App).Assembly.ToString()))));
    }
}