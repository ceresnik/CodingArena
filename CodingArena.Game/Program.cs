using System.Threading.Tasks;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    class Program
    {
        static async Task Main()
        {
            System.Console.WriteLine("Starting Coding Arena Game...");
            var config = new GameConfiguration();
            var output = System.Console.Out;
            var engine = new GameEngine(config, output);
            IBattlefieldSize size = config.BattlefieldSize;
            var match = engine.CreateMatch();

            for (int i = 0; i < config.MaxRounds; i++)
            {
                var battlefield = new Battlefield(size.Width, size.Height);
                var factory = new BotFactory(output, battlefield);
                var bots = factory.CreateBots();
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartAsync(bots, battlefield);
                roundResult.DisplayTo(output);
                match.Process(roundResult);
                await match.WaitForNextRoundAsync();
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
