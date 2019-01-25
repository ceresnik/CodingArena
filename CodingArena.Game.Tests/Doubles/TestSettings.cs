using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Tests.Doubles
{
    internal class TestSettings : ISettings
    {
        public TestSettings()
        {
            BattlefieldSize = new Size(100, 100);
        }

        public Size BattlefieldSize { get; set; }
    }
}