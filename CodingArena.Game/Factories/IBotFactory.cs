using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using CodingArena.Game.Entities;
using CodingArena.Player.Implement;

namespace CodingArena.Game.Factories
{
    public interface IBotFactory
    {
        IReadOnlyCollection<IBattleBot> Create(IBattlefield battlefield);
    }

    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        private ISettings Settings { get; }
        private IBotWorkshop BotWorkshop { get; }
        private IOutput Output { get; }

        [ImportingConstructor]
        public BotFactory(ISettings settings, IBotWorkshop botWorkshop, IOutput output)
        {
            Settings = settings;
            BotWorkshop = botWorkshop;
            Output = output;
        }

        public IReadOnlyCollection<IBattleBot> Create(IBattlefield battlefield)
        {
            try
            {
                var result = new Collection<IBattleBot>();
                var files = AssemblyFiles();
                foreach (var file in files)
                {
                    var assembly = Assembly.Load(File.ReadAllBytes(file));
                    var botAIType = FindBotAIType(assembly);

                    if (botAIType != null)
                    {
                        var botAI = Activator.CreateInstance(botAIType) as IBotAI;
                        var bot = BotWorkshop.Create(botAI);
                        result.Add(bot);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Output.Error(e.Message);
                return new List<IBattleBot>();
            }
        }

        private static IOrderedEnumerable<string> AssemblyFiles()
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
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            DeleteFiles(targetDir);

            var orderedFiles = GetOrderedFilesByAge(sourceDir);

            foreach (var file in orderedFiles)
            {
                var fileName = Path.GetFileName(file);
                if (fileName != null)
                {
                    File.Copy(file, Path.Combine(targetDir, fileName));
                }
            }

            return GetOrderedFilesByAge(targetDir);
        }

        private static void DeleteFiles(string targetDir) =>
            Directory.GetFiles(targetDir, "*.dll", SearchOption.AllDirectories).ToList().ForEach(File.Delete);

        private static IOrderedEnumerable<string> GetOrderedFilesByAge(string sourceDir) =>
            Directory.GetFiles(sourceDir, "*.dll", SearchOption.AllDirectories).OrderBy(f => new FileInfo(f).CreationTime);

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