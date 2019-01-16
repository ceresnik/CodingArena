using System.Threading.Tasks;

namespace CodingArena.Game.Console
{
    class Program
    {
        static async Task Main()
        {
            System.Console.WriteLine("Starting Coding Arena Game...");
            var config = new GameConfiguration();
            var engine = new GameEngine(config, System.Console.Out);
            var factory = new BotFactory();
            var battlefield = new Battlefield(config.BattlefieldSize);
            var match = engine.CreateMatch();

            for (int i = 0; i < config.MaxRounds; i++)
            {
                var bots = factory.CreateBots();
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartRoundAsync(bots, battlefield);
                roundResult.DisplayTo(System.Console.Out);
                await match.WaitForNextRoundAsync();
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
