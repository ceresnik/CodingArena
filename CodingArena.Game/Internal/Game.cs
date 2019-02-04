using System.ComponentModel.Composition;

namespace CodingArena.Game.Internal
{
    [Export(typeof(IGame))]
    internal class Game : IGame
    {
        public void Start()
        {
        }
    }
}