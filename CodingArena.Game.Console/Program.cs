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
                ContainerFactory.Create().GetExportedValue<IGame>().Start();
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
