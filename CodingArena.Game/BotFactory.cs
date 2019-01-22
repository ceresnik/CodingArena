using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal sealed class BotFactory
    {
        public BotFactory(TextWriter output, Battlefield battlefield)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        private TextWriter Output { get; }

        private Battlefield Battlefield { get; }

        public ICollection<Bot> Create()
        {
            var result = new Collection<Bot>();

            Output.WriteLine("Loading bots...");
            foreach (var file in AssemblyFiles())
            {
                var assembly = Load(file);
                var botAIType = FindBotAIType(assembly);

                if (botAIType != null)
                {
                    var bot = CreateBotInstance(botAIType);
                    Output.WriteLine($" * {bot.Name}");
                    result.Add(bot);
                }
            }

            return result;
        }

        private static Assembly Load(string file) => Assembly.LoadFile(file);

        private static string[] AssemblyFiles() => Directory.GetFiles(SearchDirectory(), "*.dll", SearchOption.AllDirectories);

        private static string SearchDirectory() => AppDomain.CurrentDomain.BaseDirectory;

        private static Type FindBotAIType(Assembly assembly) => assembly.ExportedTypes.FirstOrDefault(IsBotAIType);

        private static bool IsBotAIType(Type t) => typeof(IBotAI).IsAssignableFrom(t) && t.IsClass;

        private static IBotAI CreateBotAI(Type botAIType) => Activator.CreateInstance(botAIType) as IBotAI;

        private Bot CreateBotInstance(Type botAIType) => new Bot(CreateBotAI(botAIType), Battlefield);
    }
}