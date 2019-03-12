using CodingArena.Player;
using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;

namespace CodingArena.Game.Entities
{
    public interface IBattleBot : IBot
    {
        Model Model { get; }
        int MaxHP { get; }
        int HP { get; }
        int MaxEP { get; }
        int EP { get; }
        int MaxSP { get; }
        int SP { get; }
        IBattlefieldPlace Position { get; }
        IOwnBot InsideView { get; }
        IEnemy OutsideView { get; }
        string DestroyedBy { get; set; }
        void PositionTo(IBattlefield battlefield, int x, int y);
        void ExecuteTurnAction(IEnumerable<IBattleBot> enemies);
        void DrainEnergy(int energyPoints);
        void TakeDamage(int damage);
        void TakeDamage(int damage, IBattleBot attacker);
        event EventHandler Exploded;
        int Kills { get; set; }
        int Deaths { get; set; }
        string Action { get; set; }
        double DistanceTo(IOwnBot insideView);
        double DistanceTo(IEnemy outsideView);
        IBattleBot Target { get; }
    }
}