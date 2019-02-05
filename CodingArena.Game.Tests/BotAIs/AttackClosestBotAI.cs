using System.Collections.Generic;
using System.Linq;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class AttackClosestBotAI : IBotAI
    {
        public string BotName => "Attack Closest Bot";

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            var ownPlace = battlefield[ownBot];
            var closestEnemy = enemies.FirstOrDefault();
            var minDistance = ownPlace.DistanceTo(battlefield[closestEnemy]);
            if (closestEnemy != null)
            {
                foreach (var enemy in enemies.Except(new[] { closestEnemy }))
                {
                    var distance = ownPlace.DistanceTo(battlefield[enemy]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestEnemy = enemy;
                    }
                }

                return TurnAction.Attack(closestEnemy);
            }

            return TurnAction.Idle();
        }
    }
}