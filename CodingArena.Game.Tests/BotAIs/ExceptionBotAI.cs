using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class ExceptionBotAI : IBotAI
    {
        public string BotName => "Exception Bot";
        public Model Model => Model.Tinker;

        public ITurnAction GetTurnAction(
            IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefieldView battlefield)
        {
            throw new Exception();
        }
    }
}