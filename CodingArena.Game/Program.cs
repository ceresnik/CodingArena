using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Starting Coding Arena Game...");
            try
            {
                var container = CreateCompositionContainer();

                var output = new Output();
                var settings = container.GetExportedValue<ISettings>();
                var engine = container.GetExportedValue<IGameEngine>();
                var size = settings.BattlefieldSize;
                var match = engine.CreateMatch();

                for (int i = 0; i < settings.MaxRounds; i++)
                {
                    var battlefield = new Battlefield(settings);
                    output.Battlefield(battlefield);
                    var factory = new BotFactory(output, battlefield, settings);
                    var bots = factory.CreateBots().ToList();
                    var round = match.CreateRound();
                    var roundResult = await round.StartAsync(bots, battlefield);
                    output.RoundResult(roundResult);

                    match.Process(roundResult);
                    await match.WaitForNextRoundAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Game is broken.");
                Console.WriteLine($"Error message: {e}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static CompositionContainer CreateCompositionContainer()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.Load("CodingArena.Game")));
            var container = new CompositionContainer(catalog);
            return container;
        }
    }
}
