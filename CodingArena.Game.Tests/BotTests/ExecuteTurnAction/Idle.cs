using System.Collections.Generic;
using CodingArena.Game.Entities;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class Idle : TestFixture
    {
        [Test]
        public void NothingChanged()
        {
            BotAI.TurnAction = TurnAction.Idle();
            var position = Bot.Position;
            var hp = Bot.HP;
            var sp = Bot.SP;
            var ep = Bot.EP;
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.Position).Is(position);
            Verify.That(Bot.HP).Is(hp);
            Verify.That(Bot.SP).Is(sp);
            Verify.That(Bot.EP).Is(ep);
        }
    }
}