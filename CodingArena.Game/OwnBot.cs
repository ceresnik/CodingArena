using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class OwnBot : IOwnBot
    {
        public OwnBot(Bot bot)
        {
            Bot = bot;
        }

        public string Name => Bot.Name;
        public float Damage => Bot.Damage;
        public float Shield => Bot.Shield;
        public float Energy => Bot.Energy;
        private Bot Bot { get; }
    }
}