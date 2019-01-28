using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Console
{
    internal class OwnBot : IOwnBot
    {
        public OwnBot(Bot bot)
        {
            Bot = bot;
        }

        public string Name => Bot.Name;
        public IBattlefieldPlace Position => Bot.Position;
        public float Damage => Bot.Damage;
        public float Shield => Bot.Shield;
        public float Energy => Bot.Energy;
        private Bot Bot { get; }
    }
}