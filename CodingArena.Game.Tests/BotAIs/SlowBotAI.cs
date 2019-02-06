using System;
using System.Collections.Generic;
using System.Threading;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class SlowBotAI : IBotAI
    {
        public string BotName => "Slow Bot";
        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return TurnAction.Idle();
        }
    }
}