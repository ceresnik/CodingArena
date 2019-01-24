using System;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Starting Coding Arena Game...");
            try
            {
                var config = new GameConfiguration();
                var output = new Output();
                var engine = new GameEngine(config, output);
                IBattlefieldSize size = config.BattlefieldSize;
                var match = engine.CreateMatch();

                for (int i = 0; i < config.MaxRounds; i++)
                {
                    var battlefield = new Battlefield(size.Width, size.Height);
                    output.Battlefield(battlefield);
                    var factory = new BotFactory(output, battlefield, config);
                    var bots = factory.CreateBots().ToList();
                    var round = await match.CreateRoundAsync();
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
    }
}
