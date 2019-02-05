using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotTests
{
    internal class TestBotAI : IBotAI
    {
        public string BotName => "TestBot";
        public ITurnAction TurnAction { get; set; }

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            return TurnAction;
        }
    }
}