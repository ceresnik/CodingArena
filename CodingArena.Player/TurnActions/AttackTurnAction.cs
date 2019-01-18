using System;

namespace CodingArena.Player.TurnActions
{
    public sealed class AttackTurnAction : ITurnAction
    {
        internal AttackTurnAction(IEnemy enemy)
        {
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IEnemy Enemy { get; }
    }
}