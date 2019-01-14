using System.Threading.Tasks;
using static System.Console;

namespace Game.Console
{
    class Program
    {
        static async Task Main()
        {
            WriteLine("Starting Coding Arena Game...");
            var config = new GameConfiguration();
            var engine = new GameEngine(config, Out);
            var factory = new BotFactory();
            var battlefield = new Battlefield(config.BattlefieldSize);
            var match = engine.CreateMatch();
            for (int i = 0; i < config.MaxRounds; i++)
            {
                var bots = factory.CreateBots();
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartRoundAsync(bots, battlefield);
                roundResult.DisplayTo(Out);
                await match.WaitForNextRoundAsync();
            }

            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
