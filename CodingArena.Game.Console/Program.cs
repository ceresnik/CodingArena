using System;
using static System.Console;

namespace CodingArena.Game.Console
{
    class Program
    {
        public static void Main()
        {
            try
            {
                var container = ContainerFactory.Create();
                var game = container.GetExportedValue<IGame>();
                var output = container.GetExportedValue<IOutput>();
                output.Observe(game);
                game.Start();
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
