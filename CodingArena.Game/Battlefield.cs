using System;
using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class Battlefield : IBattlefield
    {
        public Battlefield(IBattlefieldSize size, IBattlefieldPlace[,] places)
        {
            Size = size;
            Places = places;
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
                        if (Places[x, y]?.Object == battlefieldObject)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }

        public IBattlefieldPlace this[IRobot robot]
        {
            get
            {
                if (robot == null)
                {
                    throw new ArgumentNullException(nameof(robot));
                }

                for (int y = 0; y < Size.Height; y++)
                {
                    for (int x = 0; x < Size.Width; x++)
                    {
                        if (Places[x, y]?.Object as IRobot == robot)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }
    }
}