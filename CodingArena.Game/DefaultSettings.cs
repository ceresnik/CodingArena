using System.ComponentModel.Composition;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    [Export(typeof(ISettings))]
    internal class DefaultSettings : ISettings
    {
        private Size myBattlefieldSize;

        public Size BattlefieldSize
        {
            get => myBattlefieldSize;
            set => myBattlefieldSize = value;
        }
    }

    public interface ISettings
    {
        Size BattlefieldSize { get; set; }
    }
}