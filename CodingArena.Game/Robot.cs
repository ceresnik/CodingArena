using System;
using CodingArena.Player;

namespace CodingArena.Game
{
    internal class Robot : IRobot
    {
        public Robot(int maxHP, int hp, int maxSP, int sp)
        {
            if (maxHP <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxHP), maxHP,
                    "Value is less than zero or equal to 0.");
            if (maxSP < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSP), maxSP,
                    "Value is less than 0.");
            if (hp < 0)
                throw new ArgumentOutOfRangeException(nameof(hp), hp,
                    "Value is less than 0.");
            if (sp < 0)
                throw new ArgumentOutOfRangeException(nameof(sp), sp,
                    "Value is less than 0.");
            MaxHealthPoints = maxHP;
            HealthPoints = hp;
            MaxShieldPoints = maxSP;
            ShieldPoints = sp;
        }

        public int MaxHealthPoints { get; }

        public int HealthPoints { get; }

        public double HealthPercentage => 
            HealthPoints * 100 / (double) MaxHealthPoints;

        public int MaxShieldPoints { get; }

        public int ShieldPoints { get; }

        public double ShieldPercentage =>
            ShieldPoints * 100 / (double) MaxShieldPoints;
    }
}
