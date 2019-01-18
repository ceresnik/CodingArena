using System;

namespace CodingArena.Player.TurnActions
{
    public static partial class TurnAction
    {
        public sealed partial class Attack : ITurnAction
        {
            private Attack(IEnemy enemy)
            {
                Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            }

            public static Attack Target(IEnemy enemy) => new Attack(enemy);
            public IEnemy Enemy { get; }
        }
    }
}