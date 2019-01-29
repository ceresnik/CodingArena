using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Threading.Tasks;

namespace CodingArena.Game.Console
{
    class Program
    {
        static async Task Main()
        {
            System.Console.WriteLine("Starting Coding Arena Game...");
            try
            {
                var container = CreateCompositionContainer();

                var output = new Output();
                var settings = container.GetExportedValue<ISettings>();
                var engine = container.GetExportedValue<IGameEngine>();
                var match = engine.CreateMatch();

                for (int i = 0; i < settings.MaxRounds; i++)
                {
                    var round = match.CreateRound();
                    var roundResult = await round.StartAsync();
                    output.RoundResult(roundResult);

                    match.Process(roundResult);
                    await match.WaitForNextRoundAsync();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Game is broken.");
                System.Console.WriteLine($"Error message: {e}");
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }

        private static CompositionContainer CreateCompositionContainer()
        {
            var catalog = new AggregateCatalog(
                new AssemblyCatalog(Assembly.Load("CodingArena.Game")),
                new AssemblyCatalog(Assembly.Load("CodingArena.Game.Console")));
            var container = new CompositionContainer(catalog);
            return container;
        }
    }
}
