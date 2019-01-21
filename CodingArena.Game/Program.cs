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
            IBattlefieldSize size = config.BattlefieldSize;
            var battlefield = new Battlefield(size.Width, size.Height);
            var factory = new AutomataFactory(battlefield);
            var match = engine.CreateMatch();

            for (int i = 0; i < config.MaxRounds; i++)
            {
                var mechWarriors = factory.Create();
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartAsync(mechWarriors, battlefield);
                roundResult.DisplayTo(System.Console.Out);
                await match.WaitForNextRoundAsync();
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
