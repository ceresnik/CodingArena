using System;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal class Bot : IBattlefieldObject
    {
        public Bot(IBotAI botAI, Battlefield battlefield)
        {
            BotAI = botAI ?? throw new ArgumentNullException(nameof(botAI));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            if (string.IsNullOrWhiteSpace(botAI.BotName))
                throw new ArgumentException($"{nameof(botAI)} does not define {nameof(botAI.BotName)}.");
            MaxHP = 1000;
            HP = MaxHP;
            MaxSP = 1000;
            SP = MaxSP;
            MaxEP = 1000;
            EP = MaxEP;
        }

        public string Name => BotAI.BotName;
        public float Damage => 100 - Health;
        public float Shield => SP / (float)MaxSP;
        public float Energy => EP / (float)MaxEP;
        public IBattlefieldPlace Position { get; set; }
        private IBotAI BotAI { get; }
        private Battlefield Battlefield { get; }
        private int MaxHP { get; set; }
        private int HP { get; set; }
        private float Health => HP / (float) MaxHP;
        private int MaxSP { get; set; }
        private int SP { get; set; }
        private int MaxEP { get; set; }
        private int EP { get; set; }
        private IOwnBot InsideView => new OwnBot(this);
        private IEnemy OutsideView => new Enemy(this);
    }
}