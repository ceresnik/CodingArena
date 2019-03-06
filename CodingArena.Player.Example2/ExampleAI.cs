using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Player.Example2
{
    public class ExampleAI : IBotAI
    {
        public string BotName => "Example Bot 2";
        public Model Model => Model.Proto;

        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            if (!enemies.Any()) return TurnAction.Idle();

            if (ownBot.Energy.Percent < 10) return TurnAction.Recharge.Battery();

            var enemy = enemies.First();

            if (ownBot.Health.Percent < 50 && ownBot.Shield.Percent < 50)
            {
                if (ownBot.Energy.Actual > 110) return TurnAction.Recharge.Shield(100);
                return TurnAction.Move.AwayFrom(enemy.Position);
            }

            if (ownBot.DistanceTo(enemy) < (double)Attack.MaxRange / 2)
            {
                return TurnAction.Attack(enemy);
            }

            return TurnAction.Move.Towards(enemy.Position);
        }
    }
}