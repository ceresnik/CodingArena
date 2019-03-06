using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class AttackFirstBotAI : IBotAI
    {
        public string BotName => "Attack First Enemy Bot";
        public Model Model => Model.Tinker;

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            var enemy = enemies.FirstOrDefault();
            return enemy != null ? TurnAction.Attack(enemy) : TurnAction.Idle();
        }
    }
}