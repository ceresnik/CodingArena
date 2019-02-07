using CodingArena.Game.Internal;
using System.ComponentModel.Composition;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Factories
{
    public interface IBattlefieldFactory
    {
        IBattlefield Create();
    }

    [Export(typeof(IBattlefieldFactory))]
    internal class BattlefieldFactory : IBattlefieldFactory
    {
        private ISettings Settings { get; }

        [ImportingConstructor]
        public BattlefieldFactory(ISettings settings) => Settings = settings;

        public IBattlefield Create() =>
            new Battlefield(Settings.BattlefieldWidth, Settings.BattlefieldHeight);
    }
}