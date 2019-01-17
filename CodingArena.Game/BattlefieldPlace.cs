using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class BattlefieldPlace : IBattlefieldPlace
    {
        public BattlefieldPlace(int x, int y)
            :this(x,y, null)
        {
        }

        public BattlefieldPlace(int x, int y, IBattlefieldObject battlefieldObject)
        {
            X = x;
            Y = y;
            Object = battlefieldObject;
        }

        private int X { get; }

        private int Y { get; }

        public bool IsEmpty => Object == null;

        public IBattlefieldObject Object { get; }

        public double DistanceTo(int x, int y) => 
            Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));

        public double DistanceTo(IBattlefieldPlace place)
        {
            if (place is BattlefieldPlace p)
                return DistanceTo(p.X, p.Y);

            throw new InvalidCastException(
                $"Invalid implementation of {typeof(IBattlefieldPlace)} interface.");
        }
    }
}