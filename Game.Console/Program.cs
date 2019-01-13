using System.Threading.Tasks;
using static System.Console;

namespace Game.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Starting Coding Arena Game...");
            var config = new GameConfiguration();
            var engine = new GameEngine(config);
            var factory = new BotFactory();
            var battlefield = new Battlefield(config.BattlefieldSize);
            var match = engine.CreateMatch();
            var bots = factory.CreateBots();
            var round = await match.StartMatchAsync();
            var roundResult = await round.StartRoundAsync(bots, battlefield);
            await engine.WaitForNextRoundAsync();
        }
    }
}
