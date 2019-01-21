using System;
using CodingArena.Player;

namespace CodingArena.Game
{
    public class MyRobot : Robot, IMyRobot
    {
        public MyRobot(int maxEP, int ep, int maxHP, int hp, int maxSP, int sp) 
            : base(maxHP, hp, maxSP, sp)
        {
            if (maxEP < 0)
                throw new ArgumentOutOfRangeException(nameof(maxEP), maxEP,
                    "Value is less than 0.");
            if (ep < 0)
                throw new ArgumentOutOfRangeException(nameof(ep), ep,
                    "Value is less than 0.");
            if (maxEP < ep)
                throw new ArgumentOutOfRangeException(nameof(maxEP), maxEP,
                    $"Value is less than parameter {nameof(ep)} value {ep}.");

            MaxEP = maxEP;
            EP = ep;
        }

        public int MaxEP { get; }
        public int EP { get; }
        public double EPPercentage =>
            EP * 100 / (double)MaxEP;
    }
}