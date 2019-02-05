using CodingArena.Player;
using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Internal
{
    internal class Battlefield : IBattlefield
    {
        private IDictionary<IBattleBot, IBattlefieldPlace> Dictionary { get; }

        public Battlefield(int width, int height)
        {
            Width = width;
            Height = height;
            Dictionary = new Dictionary<IBattleBot, IBattlefieldPlace>();
        }

        public int Width { get; }
        public int Height { get; }

        public IBattlefieldPlace this[int x, int y] => throw new System.NotImplementedException();

        public IBattlefieldPlace this[IOwnBot ownBot] => throw new System.NotImplementedException();

        public IBattlefieldPlace this[IEnemy enemy]
        {
            get
            {
                if (enemy == null) throw new ArgumentNullException(nameof(enemy));
                return Dictionary
                    .Where(pair => pair.Key.OutsideView == enemy)
                    .Select(pair => this[pair.Key]).FirstOrDefault();
            }
        }

        public bool IsEmpty(IBattlefieldPlace battlefieldPlace) => throw new System.NotImplementedException();

        public bool IsOutOfRange(int x, int y) => x < 0 || y < 0 || x > Width - 1 || y > Height - 1;

        public IBattlefieldPlace this[IBattleBot battleBot]
        {
            get
            {
                if (battleBot == null) throw new ArgumentNullException(nameof(battleBot));
                if (Dictionary.ContainsKey(battleBot))
                {
                    return Dictionary[battleBot];
                }

                return null;
            }
        }

        public void Set(IBattleBot battleBot, int newX, int newY)
        {
            if (battleBot == null) throw new ArgumentNullException(nameof(battleBot));
            if (IsOutOfRange(newX, newY)) throw new ArgumentOutOfRangeException();

            var newPlace = new BattlefieldPlace(newX, newY);
            if (Dictionary.ContainsKey(battleBot))
            {
                Dictionary[battleBot] = newPlace;
            }
            else
            {
                Dictionary.Add(battleBot, newPlace);
            }
        }
    }
}