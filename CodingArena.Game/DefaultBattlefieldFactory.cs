using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IBattlefieldFactory))]
    internal class DefaultBattlefieldFactory : IBattlefieldFactory
    {
        private ISettings Settings { get; }

        [ImportingConstructor]
        public DefaultBattlefieldFactory(ISettings settings) => Settings = settings;

        public IBattlefield Create() => 
            new Battlefield(Settings.BattlefieldWidth, Settings.BattlefieldHeight);
    }
}