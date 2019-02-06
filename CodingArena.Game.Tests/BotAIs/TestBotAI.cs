using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotAIs
{
    internal class TestBotAI : IBotAI
    {
        public string BotName => "TestBot";
        public ITurnAction TurnAction { get; set; }
        public static IBotAI AttackFirstEnemy => new AttackFirstBotAI();
        public static IBotAI Idle => new TestBotAI { TurnAction = Player.TurnActions.TurnAction.Idle() };
        public static IBotAI Exception => new ExceptionBotAI();
        public static IBotAI Slow => new SlowBotAI();
        public static IBotAI SeekAndDestroy => new SeekAndDestroyAI();

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            return TurnAction;
        }
    }
}