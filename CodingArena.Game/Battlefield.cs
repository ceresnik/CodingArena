using System;
using System.Collections.Generic;
using System.Linq;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Exceptions;

namespace CodingArena.Game
{
    public interface IBattlefield : IBattlefieldView
    {
        void Position(IBattlefieldObject battlefieldObject, IBattlefieldPlace battlefieldPlace);
    }

    internal class Battlefield : IBattlefield
    {
        private IDictionary<IBattlefieldObject, IBattlefieldPlace> Dictionary { get; }

        public Battlefield(int width, int height)
        {
            Width = width;
            Height = height;
            Dictionary = new Dictionary<IBattlefieldObject, IBattlefieldPlace>();
        }

        public int Width { get; }

        public int Height { get; }

        public IReadOnlyCollection<IBattlefieldObject> Objects => Dictionary.Keys.ToList();

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
                if (x > Width)
                {
                    throw new ArgumentOutOfRangeException(nameof(x), x,
                        $"{nameof(x)} could not be greater than {Width}.");
                }
                if (y > Height)
                {
                    throw new ArgumentOutOfRangeException(nameof(y), y,
                        $"{nameof(y)} could not be greater than {Height}.");
                }                

                return new BattlefieldPlace(x, y);
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
                if (!Dictionary.ContainsKey(battlefieldObject))
                {
                    throw new BattlefieldPlaceNotFoundException(
                        $"Failed to find battlefield place for {battlefieldObject.Name}");
                }

                return Dictionary[battlefieldObject];
            }
        }

        public bool IsEmpty(IBattlefieldPlace battlefieldPlace) => !Dictionary.Values.Contains(battlefieldPlace);

        public void Position(IBattlefieldObject battlefieldObject, IBattlefieldPlace battlefieldPlace)
        {
            if (battlefieldObject == null)
                throw new ArgumentNullException(nameof(battlefieldObject));

            if (battlefieldPlace == null)
                throw new ArgumentNullException(nameof(battlefieldPlace));

            if (!Dictionary.ContainsKey(battlefieldObject))
                throw new ArgumentException("Failed to find specified object on battlefield.", nameof(battlefieldObject));

            Dictionary[battlefieldObject] = battlefieldPlace;
        }

        public override string ToString() => $"Battlefield [{nameof(Width)}: {Width}, {nameof(Height)}: {Height}]";
        public IBattlefieldView View => this;
    }
}