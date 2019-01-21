using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal sealed class AutomataFactory
    {
        private readonly Battlefield battlefield;

        public AutomataFactory(Battlefield battlefield)
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
                    if (typeof(IBot).IsAssignableFrom(t) && t.IsClass)
                    {
                        botType = t;
                        break;
                    }
                }

                if (botType != null)
                {
                    var bot = Activator.CreateInstance(botType) as IBot;
                    var mechWarrior = new Bot(battlefield, bot, 1000, 1000, 1000);
                    Console.WriteLine($" * {mechWarrior.Name}");
                    result.Add(mechWarrior);
                }
            }

            return result;
        }
    }
}