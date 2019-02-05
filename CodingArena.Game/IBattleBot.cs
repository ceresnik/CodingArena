using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;
using CodingArena.Player;

namespace CodingArena.Game
{
    public interface IBattleBot : IBot
    {
        int MaxHP { get; }
        int HP { get; }
        int MaxEP { get; }
        int EP { get; }
        int MaxSP { get; }
        int SP { get; }
        IBattlefieldPlace Position { get; }
        IEnemy OutsideView { get; }
        void PositionTo(int x, int y);
        void ExecuteTurnAction(IEnumerable<IBattleBot> enemies);
        void DrainEnergy(int energyPoints);
        void TakeDamage(int damage);
        event EventHandler Exploded;
    }
}