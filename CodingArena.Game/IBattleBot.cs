using CodingArena.Player.Battlefield;
using System;

namespace CodingArena.Game
{
    public interface IBattleBot
    {
        int MaxHP { get; }
        int HP { get; }
        int MaxEP { get; }
        int EP { get; }
        IBattlefieldPlace Position { get; }
        void PositionTo(int x, int y);
        void ExecuteTurnAction();
        void DrainEnergy(int energyPoints);
        event EventHandler Exploded;
    }
}