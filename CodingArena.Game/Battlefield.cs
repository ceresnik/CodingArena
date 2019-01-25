using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public class Battlefield : IBattlefield
    {
        public Battlefield(int width, int height)
        {
            Size = new BattlefieldSize(width, height);
            Places = new IBattlefieldPlace[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Places[x, y] = new BattlefieldPlace(x, y);
                }
            }
        }

        private IBattlefieldPlace[,] Places { get; }

        public IBattlefieldSize Size { get; }

        public IBattlefieldPlace this[int x, int y]
        {
            get
            {
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(x), x,
                        $"{nameof(x)} could not be less than zero.");
                }
                if (y < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(y), y,
                        $"{nameof(y)} could not be less than zero.");
                }
                if (x > Size.Width)
                {
                    throw new ArgumentOutOfRangeException(nameof(x), x,
                        $"{nameof(x)} could not be greater than {Size.Width}.");
                }
                if (y > Size.Height)
                {
                    throw new ArgumentOutOfRangeException(nameof(y), y,
                        $"{nameof(y)} could not be greater than {Size.Height}.");
                }

                return Places[x, y];
            }
            set => Places[x, y] = value;
        }

        public IBattlefieldPlace this[IBattlefieldObject battlefieldObject]
        {
            get
            {
                if (battlefieldObject == null)
                {
                    throw new ArgumentNullException(nameof(battlefieldObject));
                }

                for (int y = 0; y < Size.Height; y++)
                {
                    for (int x = 0; x < Size.Width; x++)
                    {
                        if (Places[x, y]?.Object?.Name == battlefieldObject.Name)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }

        public bool Move(Bot bot, int newX, int newY)
        {
            int oldX = bot.Position.X;
            int oldY = bot.Position.Y;

            if (this[newX, newY].IsEmpty)
            {
                this[oldX, oldY] = new BattlefieldPlace(oldX, oldY);
                this[newX, newY] = new BattlefieldPlace(newX, newY, bot);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Battlefield {nameof(Size)}: {Size}";
        }
    }
}