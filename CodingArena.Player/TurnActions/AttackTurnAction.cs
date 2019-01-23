using System;

namespace CodingArena.Player.TurnActions
{
    public sealed class AttackTurnAction : ITurnAction
    {
        internal AttackTurnAction(IEnemy enemy)
        {
            Target = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public int EnergyCost => 10;

        public IEnemy Target { get; }
    }
}