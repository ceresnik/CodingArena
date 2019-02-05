using System.Collections.Generic;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class RechargeBattery : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            BotAI.TurnAction = TurnAction.Recharge.Battery();
            EnergyCost = BotAI.TurnAction.EnergyCost;
            RechargeAmount = ((Player.TurnActions.RechargeBattery)BotAI.TurnAction).RechargeAmount;
        }

        [Test]
        public void FullBattery()
        {            
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.EP).Is(Bot.MaxEP);
        }

        [Test]
        public void HalfBattery()
        {
            Bot.DrainEnergy(Bot.MaxEP / 2);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.EP).Is(Bot.MaxEP / 2 + RechargeAmount - EnergyCost);
        }

        [Test]
        public void DoNotRechargeEmptyBattery()
        {
            Bot.DrainEnergy(Bot.EP);
            Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.EP).Is(0);
        }
    }
}