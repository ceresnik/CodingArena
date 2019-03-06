using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class SeekAndDestroyAI : IBotAI
    {
        public SeekAndDestroyAI(string botName)
        {
            BotName = botName;
        }

        public string BotName { get; }
        public Model Model => Model.Tinker;
        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            if (enemies.Any())
            {
                var enemy = enemies.First();
                var ownPlace = battlefield[ownBot];
                var enemyPlace = battlefield[enemy];
                return ownPlace.DistanceTo(enemyPlace) > 3
                    ? TurnAction.Move.Towards(enemyPlace)
                    : TurnAction.Attack(enemy);
            }

            return TurnAction.Idle();
        }
    }
}