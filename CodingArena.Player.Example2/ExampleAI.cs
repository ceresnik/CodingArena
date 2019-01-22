using System.Collections.Generic;
using System.Linq;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Example2
{
    public class ExampleAI : IBotAI
    {
        public string BotName => "Example Bot 2";

        public ITurnAction TurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield)
        {
            if (enemies.Any())
            {
                var closestEnemy = FindClosestEnemy(ownBot, enemies);

                var minAttackDistance = 6;
                if (ownBot.Position.DistanceTo(closestEnemy.Position) < minAttackDistance)
                    return TurnActions.TurnAction.Attack(closestEnemy);

                var fromPlace = battlefield[ownBot];
                var toPlace = battlefield[closestEnemy];
                return TurnActions.TurnAction.Move.Towards(fromPlace, toPlace);
            }

            return TurnActions.TurnAction.Idle();
        }

        private IEnemy FindClosestEnemy(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies)
        {
            var closestEnemy = enemies.First();
            foreach (var enemy in enemies.Except(new[] { closestEnemy }))
            {
                if (ownBot.Position.DistanceTo(enemy.Position) < ownBot.Position.DistanceTo(closestEnemy.Position))
                {
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

    }
}
