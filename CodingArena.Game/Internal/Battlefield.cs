using CodingArena.Game.Entities;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Internal
{
    internal class Battlefield : IBattlefield
    {
        private IBattlefieldPlace[,] Places { get; }
        private Random Random { get; }

        public Battlefield(int width, int height)
        {
            Width = width;
            Height = height;
            Places = new IBattlefieldPlace[Width, Height];
            Initialize();
            Random = new Random();
        }

        private void Initialize()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Places[x, y] = new BattlefieldPlace(x, y);
                }
            }
        }

        public int Width { get; }
        public int Height { get; }

        public IBattlefieldPlace this[int x, int y]
        {
            get
            {
                if (IsOutOfRange(x, y)) throw new ArgumentOutOfRangeException();
                return Places[x, y];
            }
        }

        public IBattlefieldPlace this[IOwnBot ownBot]
        {
            get
            {
                if (ownBot == null) throw new ArgumentNullException(nameof(ownBot));

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (Places[x, y].Object is IBattleBot battleBot &&
                            battleBot.InsideView == ownBot)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }

        public IBattlefieldPlace this[IEnemy enemy]
        {
            get
            {
                if (enemy == null) throw new ArgumentNullException(nameof(enemy));

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (Places[x, y].Object is IBattleBot battleBot &&
                            battleBot.OutsideView == enemy)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }

        public bool IsOutOfRange(int x, int y) => x < 0 || y < 0 || x > Width - 1 || y > Height - 1;

        public IBattlefieldPlace this[IBattleBot battleBot]
        {
            get
            {
                if (battleBot == null) throw new ArgumentNullException(nameof(battleBot));

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (Places[x, y].Object is IBattleBot bot && bot == battleBot)
                        {
                            return Places[x, y];
                        }
                    }
                }

                return null;
            }
        }

        public void Set(IBattleBot battleBot, int newX, int newY)
        {
            if (battleBot == null) throw new ArgumentNullException(nameof(battleBot));
            if (IsOutOfRange(newX, newY)) throw new ArgumentOutOfRangeException();
            var oldPlace = this[battleBot];
            if (oldPlace != null)
            {
                Places[oldPlace.X, oldPlace.Y] = new BattlefieldPlace(oldPlace.X, oldPlace.Y);
            }
            Places[newX, newY] = new BattlefieldPlace(newX, newY, battleBot);
        }

        public void SetRandomly(IEnumerable<IBattleBot> bots)
        {
            foreach (var bot in bots)
            {
                var emptyPlaces = GetEmptyPlaces().ToList();
                if (emptyPlaces.Any())
                {
                    var index = Random.Next(emptyPlaces.Count);
                    var place = emptyPlaces[index];
                    bot.PositionTo(this, place.X, place.Y);
                }
                else
                {
                    throw new InvalidOperationException("No empty places found on battlefield.");
                }
            }
        }

        private IEnumerable<IBattlefieldPlace> GetEmptyPlaces()
        {
            var result = new List<IBattlefieldPlace>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (Places[x, y].IsEmpty)
                    {
                        result.Add(Places[x, y]);
                    }
                }
            }
            return result;
        }
    }
}