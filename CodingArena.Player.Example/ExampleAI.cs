using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Player.Example
{
    public class ExampleAI : IBotAI
    {
        public string BotName => "Example Bot 1";

        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            if (!enemies.Any()) return TurnAction.Idle();

            if (ownBot.SP < 50)
            {
                return TurnAction.Recharge.Shield();
            }

            var enemy = enemies.First();
            if (ownBot.DistanceTo(enemy) < (double) Attack.MaxRange / 2)
            {
                return TurnAction.Attack(enemy);
            }

            return TurnAction.Move.Towards(battlefield[ownBot], battlefield[enemy]);

        }
    }
}