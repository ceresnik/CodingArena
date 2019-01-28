using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace CodingArena.Game.Tests
{
    public static class CompositionContainerFactory
    {
        public static CompositionContainer Create()
        {
            var productCatalog = new AggregateCatalog(new AssemblyCatalog(Assembly.Load("CodingArena.Game.Console")));
            var exportProvider = new CatalogExportProvider(productCatalog);
            var testCatalog = new AssemblyCatalog(Assembly.Load("CodingArena.Game.Tests"));

            var container = new CompositionContainer(testCatalog, exportProvider);
            exportProvider.SourceProvider = container;
            return container;
        }
    }
}