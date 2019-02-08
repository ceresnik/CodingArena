using CodingArena.Game.Entities;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace CodingArena.Game.Console
{
    internal class Program
    {
        public static async Task Main()
        {
            try
            {
                var container = ContainerFactory.Create();
                var game = container.GetExportedValue<IGame>();
                var output = container.GetExportedValue<IOutput>();
                output.Observe(game);
                await game.StartAsync();
            }
            catch (Exception e)
            {
                WriteLine("Game is broken.");
                WriteLine($"Error message: {e}");
            }

            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
