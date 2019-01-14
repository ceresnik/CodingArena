using System;

namespace Game.Console
{
    internal class BattlefieldPosition
    {
        private int X { get; }
        private int Y { get; }
        private Battlefield Battlefield { get; }

        public BattlefieldPosition(int x, int y, Battlefield battlefield)
        {
            X = x;
            Y = y;
            Battlefield = battlefield;
        }

        public double DistanceTo(BattlefieldPosition position) => 
            Math.Sqrt(Math.Pow(position.X - X, 2) + Math.Pow(position.Y - Y, 2));

        public double DistanceToBorder() => 
            Math.Min(
                Math.Min(X, Battlefield.Size.Width - X), 
                Math.Min(Y, Battlefield.Size.Height - Y));
    }
}