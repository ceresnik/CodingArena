using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotTests
{
    internal class TestBotAI : IBotAI
    {
        private ITurnAction TurnAction { get; }
        public string BotName => "TestBot";

        public TestBotAI(ITurnAction turnAction)
        {
            TurnAction = turnAction;
        }

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            return TurnAction;
        }
    }
}