using System.Collections.Generic;
using System.Linq;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class AttackFirstBotAI : IBotAI
    {
        public string BotName => "Attack First Enemy Bot";

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