using System;

namespace CodingArena.Player
{
    public class Weapon
    {
        public static Weapon MachineGun => new Weapon("Machine Gun")
        {
            MinRange = 0,
            MaxRange = 5,
            MinDamage = 20,
            MaxDamage = 100,
            EnergyCost = 5,
        };

        public static Weapon RocketLauncher => new Weapon("Rocket Launcher")
        {
            MinRange = 0,
            MaxRange = 7,
            MinDamage = 30,
            MaxDamage = 30,
            EnergyCost = 10,
        };

        internal Weapon(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public double MinRange { get; private set; }

        public double MaxRange { get; private set; }

        public double MinDamage { get; private set; }

        public double MaxDamage { get; private set; }

        public int EnergyCost { get; private set; }
    }
}