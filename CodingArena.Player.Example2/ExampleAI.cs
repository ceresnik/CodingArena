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

        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield)
        {
            if (enemies.Any())
            {
                if (ownBot.Shield < 50)
                {
                    return TurnAction.Recharge.Shield();
                }
                var closestEnemy = FindClosestEnemy(ownBot, enemies);

                var minAttackDistance = 6;
                if (ownBot.Position.DistanceTo(closestEnemy.Position) < minAttackDistance)
                    return TurnAction.Attack(closestEnemy);

                var fromPlace = battlefield[ownBot];
                var toPlace = battlefield[closestEnemy];
                return TurnAction.Move.Towards(fromPlace, toPlace);
            }

            return TurnAction.Idle();
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