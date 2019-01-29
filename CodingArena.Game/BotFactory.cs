using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    [Export(typeof(IBotFactory))]
    public sealed class BotFactory : IBotFactory
    {
        [ImportingConstructor]
        public BotFactory(IOutput output, ISettings settings)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings;
        }

        private IOutput Output { get; }
        private ISettings Settings { get; }

        public IEnumerable<Bot> CreateBots(IBattlefield battlefield)
        {
            try
            {
                var result = new Collection<Bot>();
                var files = AssemblyFiles();
                foreach (var file in files)
                {
                    var assembly = Assembly.Load(File.ReadAllBytes(file));
                    var botAIType = FindBotAIType(assembly);

                    if (botAIType != null)
                    {
                        var botAI = Activator.CreateInstance(botAIType) as IBotAI;
                        var bot = new Bot(Output, botAI, battlefield, Settings);
                        battlefield.Position(bot, battlefield.GetRandomEmptyPlace());
                        result.Add(bot);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Output.Error(e.Message);
                return new List<Bot>();
            }
        }

        private static string[] AssemblyFiles()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var sourceDir = Path.Combine(baseDirectory, "Bots");
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException(
                    $"Directory {sourceDir} not found. " +
                    "Create directory and share it for players, " +
                    "so that they can copy their class libraries with bot implementation into it.");
            }
            var targetDir = Path.Combine(baseDirectory, "BotCopies");
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            var files = Directory.GetFiles(targetDir, "*.dll", SearchOption.AllDirectories);

            if (files.Any())
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            files = Directory.GetFiles(sourceDir, "*.dll", SearchOption.AllDirectories);

            if (files.Any())
            {
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    if (fileName != null)
                    {
                        File.Copy(file, Path.Combine(targetDir, fileName));
                    }
                }
            }

            return Directory.GetFiles(targetDir, "*.dll", SearchOption.AllDirectories);
        }

        private Type FindBotAIType(Assembly assembly)
        {
            try
            {
                return assembly.ExportedTypes.FirstOrDefault(IsBotAIType);
            }
            catch (TypeLoadException e)
            {
                Output.Error($"Failed to load exported types for assembly {assembly.GetName()}. " + Environment.NewLine + 
                             $"Check if latest version of {typeof(IBotAI).Assembly} is referenced. " + Environment.NewLine +
                             $"Error message: {e.Message}");
                return null;
            }
        }

        private static bool IsBotAIType(Type t) => typeof(IBotAI).IsAssignableFrom(t) && t.IsClass;
    }
}