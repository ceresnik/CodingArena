using System;
using CodingArena.Player;

namespace CodingArena.Game
{
    public class Robot : IRobot
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
            if (maxHP < hp)
                throw new ArgumentOutOfRangeException(nameof(maxHP), maxHP,
                    $"Value is less than parameter {nameof(hp)} value {hp}.");
            if (maxSP < sp)
                throw new ArgumentOutOfRangeException(nameof(maxSP), maxSP,
                    $"Value is less than parameter {nameof(sp)} value {sp}.");

            MaxHP = maxHP;
            HP = hp;
            MaxSP = maxSP;
            SP = sp;
        }

        public int MaxHP { get; }

        public int HP { get; }

        public double HPPercentage => 
            HP * 100 / (double) MaxHP;

        public int MaxSP { get; }

        public int SP { get; }

        public double SPPercentage =>
            SP * 100 / (double) MaxSP;
    }
}
