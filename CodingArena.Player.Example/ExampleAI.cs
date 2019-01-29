using System.Collections.Generic;
using System.Linq;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Example
{
    public class ExampleAI : IBotAI
    {
        public string BotName => "Example Bot 1";

        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            if (enemies.Any())
            {
                if (ownBot.Shield < 50)
                {
                    return TurnAction.Recharge.Shield();
                }
                var closestEnemy = FindClosestEnemy(ownBot, enemies, battlefield);

                var minAttackDistance = 6;
                var place = battlefield[ownBot];
                var closestEnemyPlace = battlefield[closestEnemy];
                if (place.DistanceTo(closestEnemyPlace) < minAttackDistance)
                    return TurnAction.Attack(closestEnemy);

                var fromPlace = battlefield[ownBot];
                var toPlace = battlefield[closestEnemy];
                return TurnAction.Move.Towards(fromPlace, toPlace);
            }

            return TurnAction.Idle();
        }

        private IEnemy FindClosestEnemy(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            var closestEnemy = enemies.First();
            var minDistance = GetDistance(battlefield, ownBot, closestEnemy);
            foreach (var enemy in enemies.Except(new[] {closestEnemy}))
            {
                var distance = GetDistance(battlefield, ownBot, enemy);
                if (minDistance < distance)
                {
                    closestEnemy = enemy;
                    minDistance = distance;
                }
            }

            return closestEnemy;
        }

        private static double GetDistance(IBattlefieldView battlefield, IBattlefieldObject obj1, IBattlefieldObject obj2)
        {
            var place1 = battlefield[obj1];
            var place2 = battlefield[obj2];
            return place1.DistanceTo(place2);
        }
    }
}