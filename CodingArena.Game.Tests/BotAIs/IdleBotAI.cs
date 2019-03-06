using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class IdleBotAI : IBotAI
    {
        public string BotName => "IdleBot";
        public Model Model => Model.Tinker;
        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            return TurnAction.Idle();
        }
    }
}