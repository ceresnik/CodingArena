using CodingArena.Game.Entities;
using CodingArena.Game.Factories;
using CodingArena.Game.Tests.BotAIs;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class Exceptional : TestFixture
    {
        [Test]
        public void NullTurnAction()
        {
            BotAI.TurnAction = null;
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.HP).Is(0);
            Verify.That(Bot.Deaths).Is(1);
            Verify.That(Bot.DestroyedBy).Is("system malfunction");
            Verify.That(Bot.Action).Is($"{Bot.Name} is destroyed by system malfunction.");
        }

        [Test]
        public void NotSupportedTurnAction()
        {
            BotAI.TurnAction = new NotSupportedTurnAction();
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.HP).Is(0);
            Verify.That(Bot.Deaths).Is(1);
            Verify.That(Bot.DestroyedBy).Is("system malfunction");
            Verify.That(Bot.Action).Is($"{Bot.Name} is destroyed by system malfunction.");
        }

        [Test]
        public void Exception()
        {
            var botAI = TestBotAI.Exception;
            var bot = Get<IBotWorkshop>().Create(botAI);
            bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(bot.HP).Is(0);
            Verify.That(bot.Deaths).Is(1);
            Verify.That(bot.DestroyedBy).Is("system malfunction");
            Verify.That(bot.Action).Is($"{bot.Name} is destroyed by system malfunction.");
        }

        [Test]
        public void Slow()
        {
            var botAI = TestBotAI.Slow;
            var bot = Get<IBotWorkshop>().Create(botAI);
            bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(bot.HP).Is(0);
            Verify.That(bot.Deaths).Is(1);
            Verify.That(bot.DestroyedBy).Is("system malfunction");
            Verify.That(bot.Action).Is($"{bot.Name} is destroyed by system malfunction.");
        }
    }

    internal class NotSupportedTurnAction : ITurnAction
    {
        public NotSupportedTurnAction() => EnergyCost = 0;
        public int EnergyCost { get; }
    }
}