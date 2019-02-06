using System.Collections.Generic;
using CodingArena.Game.Tests.Verification;
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
    }
}