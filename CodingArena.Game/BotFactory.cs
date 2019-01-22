using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal sealed class BotFactory
    {
        private readonly Battlefield battlefield;

        public BotFactory(Battlefield battlefield)
        {
            this.battlefield = battlefield;
        }

        public ICollection<Bot> Create()
        {
            var result = new Collection<Bot>();

            Console.WriteLine("Loading bots...");
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(directoryPath, "*.dll", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                Type botType = null;
                foreach (var t in assembly.ExportedTypes)
                {
                    if (typeof(IBotAI).IsAssignableFrom(t) && t.IsClass)
                    {
                        botType = t;
                        break;
                    }
                }

                if (botType != null)
                {
                    var ai = Activator.CreateInstance(botType) as IBotAI;
                    var bot = new Bot(ai, battlefield);
                    Console.WriteLine($" * {bot.Name}");
                    result.Add(bot);
                }
            }

            return result;
        }
    }
}