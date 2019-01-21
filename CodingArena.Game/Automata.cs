using System;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal class Automata
    {
        private readonly Battlefield battlefield;
        private readonly IBot bot;

        public Automata(Battlefield battlefield, IBot bot, int maxHP, int maxSP, int maxEP)
        {
            this.battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            this.bot = bot ?? throw new ArgumentNullException(nameof(bot));
            MaxHP = maxHP;
            HP = maxHP;
            MaxSP = maxSP;
            SP = maxSP;
            MaxEP = maxEP;
            EP = maxEP;
        }

        public string Name => bot.Name;

        public int MaxHP { get; }

        public int HP { get; }

        public int MaxSP { get; }

        public int SP { get; }

        public int MaxEP { get; }

        public int EP { get; }

        public void Execute(Turn turn)
        {
            // TODO
        }
    }
}