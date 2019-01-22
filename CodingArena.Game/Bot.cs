using System;
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
        public IBattlefieldPlace Position { get; set; }
        private IBotAI BotAI { get; }
        private Battlefield Battlefield { get; }
        private int MaxHP { get; set; }
        private int HP { get; set; }
        private float Health => HP / (float) MaxHP;
        private float Damage => 100 - Health;
        private int MaxSP { get; set; }
        private int SP { get; set; }
        private float Shield => SP / (float) MaxSP;
        private int MaxEP { get; set; }
        private int EP { get; set; }
        private float Energy => EP / (float) MaxEP;
    }
}