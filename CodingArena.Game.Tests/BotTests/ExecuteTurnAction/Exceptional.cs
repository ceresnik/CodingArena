using System.Collections.Generic;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class Exceptional : TestFixture
    {
        [Test]
        public void NullTurnAction()
        {
            BotAI.TurnAction = null;
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.HP).Is(0);
            Verify.That(Bot.Deaths).Is(1);
            Verify.That(Bot.DestroyedBy).Is("system malfunction (Error Code: Invalid turn action)");
            Verify.That(result)
                .Is($"{Bot.Name} is destroyed by system malfunction (Error Code: Invalid turn action).");
        }

        [Test]
        public void NotSupportedTurnAction()
        {
            BotAI.TurnAction = new NotSupportedTurnAction();
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.HP).Is(0);
            Verify.That(Bot.Deaths).Is(1);
            Verify.That(Bot.DestroyedBy).Is("system malfunction (Error Code: Invalid turn action)");
            Verify.That(result)
                .Is($"{Bot.Name} is destroyed by system malfunction (Error Code: Invalid turn action).");
        }
    }
    
    internal class NotSupportedTurnAction : ITurnAction
    {
        public NotSupportedTurnAction() => EnergyCost = 0;
        public int EnergyCost { get; }
    }
}