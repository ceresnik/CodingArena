using System;

namespace CodingArena.Game
{
    internal class MechWarrior
    {
        private readonly Battlefield battlefield;

        public MechWarrior(Battlefield battlefield, string name, int maxHP, int maxSP, int maxEP)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            MaxHP = maxHP;
            HP = maxHP;
            MaxSP = maxSP;
            SP = maxSP;
            MaxEP = maxEP;
            EP = maxEP;
        }

        public string Name { get; }

        public int MaxHP { get; }

        public int HP { get; }

        public int MaxSP { get; }

        public int SP { get; }

        public int MaxEP { get; }

        public int EP { get; }

        public void PlaceTo(int x, int y)
        {
            // TODO
        }
    }
}