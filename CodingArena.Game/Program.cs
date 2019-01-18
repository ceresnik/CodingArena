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
            var engine = new GameEngine(config, System.Console.Out);
            var factory = new BotFactory();
            IBattlefieldSize size = config.BattlefieldSize;
            var battlefield = new Battlefield(size, new IBattlefieldPlace[size.Width, size.Height]);
            var match = engine.CreateMatch();

            for (int i = 0; i < config.MaxRounds; i++)
            {
                var bots = factory.CreateBots();
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartAsync(bots, battlefield);
                roundResult.DisplayTo(System.Console.Out);
                await match.WaitForNextRoundAsync();
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
