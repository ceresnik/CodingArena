using System;

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
                var output = container.GetExportedValue<INewOutput>();
                output.Observe(game.Notifier);
                game.Controller.Start();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Game is broken.");
                System.Console.WriteLine($"Error message: {e}");
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
