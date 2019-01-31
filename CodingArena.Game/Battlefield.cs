using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game
{
    public interface IBattlefield : IBattlefieldView
    {
        void Position(IBattlefieldObject battlefieldObject, IBattlefieldPlace battlefieldPlace);
        IBattlefieldPlace GetRandomEmptyPlace();
        IBattlefieldPlace this[Bot bot] { get; }
    }

    internal class Battlefield : IBattlefield
    {
        private Random Random { get; }
        private IDictionary<IBattlefieldObject, IBattlefieldPlace> Dictionary { get; }

        public Battlefield(int width, int height)
        {
            Width = width;
            Height = height;
            Dictionary = new Dictionary<IBattlefieldObject, IBattlefieldPlace>();
            Random = new Random();
        }

        public int Width { get; }

        public int Height { get; }

        public IBattlefieldPlace this[int x, int y]
        {
            get
            {
                if (x < 0)
                    throw new ArgumentOutOfRangeException(nameof(x), x, $"{nameof(x)} could not be less than zero.");
                if (y < 0)
                    throw new ArgumentOutOfRangeException(nameof(y), y, $"{nameof(y)} could not be less than zero.");
                if (x > Width)
                    throw new ArgumentOutOfRangeException(nameof(x), x, $"{nameof(x)} could not be greater than {Width}.");
                if (y > Height)
                    throw new ArgumentOutOfRangeException(nameof(y), y, $"{nameof(y)} could not be greater than {Height}.");

                return new BattlefieldPlace(x, y);
            }
        }

        public IBattlefieldPlace this[IOwnBot ownBot]
        {
            get
            {
                if (ownBot == null) throw new ArgumentNullException(nameof(ownBot));

                foreach (var pair in Dictionary)
                {
                    if (pair.Key is Bot bot &&
                        bot.InsideView.Equals(ownBot) &&
                        Dictionary.ContainsKey(bot))
                    {
                        return Dictionary[bot];
                    }
                }
                throw new BattlefieldPlaceNotFoundException($"{ownBot.Name} not found on battlefield.");
            }
        }

        public IBattlefieldPlace this[IEnemy enemy]
        {
            get
            {
                if (enemy == null) throw new ArgumentNullException(nameof(enemy));

                foreach (var pair in Dictionary)
                {
                    if (pair.Key is Bot bot &&
                        bot.OutsideView.Equals(enemy) &&
                        Dictionary.ContainsKey(bot))
                    {
                        return Dictionary[bot];
                    }
                }
                throw new BattlefieldPlaceNotFoundException($"{enemy.Name} not found on battlefield.");
            }
        }

        public IBattlefieldPlace this[Bot bot]
        {
            get
            {
                if (bot == null) throw new ArgumentNullException(nameof(bot));

                if (Dictionary.ContainsKey(bot))
                {
                    return Dictionary[bot];
                }

                throw new BattlefieldPlaceNotFoundException($"{bot.Name} not found on battlefield.");
            }
        }

        public bool IsEmpty(IBattlefieldPlace battlefieldPlace) => !Dictionary.Values.Contains(battlefieldPlace);

        public void Position(IBattlefieldObject battlefieldObject, IBattlefieldPlace battlefieldPlace)
        {
            if (battlefieldObject == null)
                throw new ArgumentNullException(nameof(battlefieldObject));

            if (battlefieldPlace == null)
                throw new ArgumentNullException(nameof(battlefieldPlace));

            if (Dictionary.ContainsKey(battlefieldObject))
            {
                Dictionary[battlefieldObject] = battlefieldPlace;
            }
            else
            {
                Dictionary.Add(battlefieldObject, battlefieldPlace);
            }
        }

        public IBattlefieldPlace GetRandomEmptyPlace()
        {
            var emptyPlaces = GetEmptyBattlefieldPlaces();
            return emptyPlaces.Any() ? emptyPlaces[Random.Next(emptyPlaces.Count - 1)] : null;
        }

        private List<IBattlefieldPlace> GetEmptyBattlefieldPlaces()
        {
            var emptyPlaces = new List<IBattlefieldPlace>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var place = this[x, y];
                    if (IsEmpty(place))
                    {
                        emptyPlaces.Add(place);
                    }
                }
            }

            return emptyPlaces;
        }

        public override string ToString() => $"Battlefield [{nameof(Width)}: {Width}, {nameof(Height)}: {Height}]";
    }
}