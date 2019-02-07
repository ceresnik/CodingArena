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

            if (ownBot.EP < 105) return TurnAction.Recharge.Battery();

            var enemy = enemies.First();

            if (ownBot.HP < ownBot.MaxHP && ownBot.SP < ownBot.MaxSP)
            {
                if (ownBot.EP > 105) return TurnAction.Recharge.Shield(100);                
                return TurnAction.Move.Towards(enemy.Position, ownBot.Position);
            }

            if (ownBot.DistanceTo(enemy) < (double) Attack.MaxRange / 2)
            {
                return TurnAction.Attack(enemy);
            }

            return TurnAction.Move.Towards(ownBot.Position, enemy.Position);
        }
    }
}