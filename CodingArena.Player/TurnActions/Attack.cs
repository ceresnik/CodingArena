using System;

namespace CodingArena.Player.TurnActions
{
    public sealed class Attack : ITurnAction
    {
        public const int MaxRange = 5;
        public const int MaxDamage = 100;

        internal Attack(IEnemy enemy)
        {
            Target = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public int EnergyCost => 5;

        public IEnemy Target { get; }
    }
}