using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game.Tests.BotTests
{
    internal class BotAIStub : IBotAI
    {
        public BotAIStub()
        {
            BotName = "TestBot";
        }

        public string BotName { get; }

        public ITurnAction Action { get; set; }

        public ITurnAction TurnAction(
            IOwnBot ownBot, 
            IReadOnlyCollection<IEnemy> enemies, 
            IBattlefield battlefield)
        {
            return Action;
        }
    }
}