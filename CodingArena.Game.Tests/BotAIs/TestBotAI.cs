using System;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System.Collections.Generic;
using System.Threading;

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

        public ITurnAction GetTurnAction(
            IOwnBot ownBot,
            IReadOnlyCollection<IEnemy> enemies,
            IBattlefieldView battlefield)
        {
            return TurnAction;
        }
    }

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