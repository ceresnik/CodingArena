using System.Collections.Generic;
using System.Linq;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Example
{
    public class ExampleAI : IBotAI
    {
        public string BotName => "Example Bot";

        public ITurnAction TurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield)
        {
            if (enemies.Any())
            {              
                var closestEnemy = FindClosestEnemy(ownBot, enemies);

                var minAttackDistance = 6;
                if (ownBot.Position.DistanceTo(closestEnemy.Position) < minAttackDistance)
                    return TurnActions.TurnAction.Attack(closestEnemy);

                return TurnActions.TurnAction.Move.Towards(battlefield[ownBot], battlefield[closestEnemy]);
            }

            return TurnActions.TurnAction.Idle();
        }

        private IEnemy FindClosestEnemy(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies)
        {
            var closestEnemy = enemies.First();
            foreach (var enemy in enemies.Except(new[] {closestEnemy}))
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