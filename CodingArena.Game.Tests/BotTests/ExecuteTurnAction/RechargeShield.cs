using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class RechargeShield : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            BotAI.TurnAction = TurnAction.Recharge.Shield();
            if (BotAI.TurnAction is Player.TurnActions.RechargeShield rechargeShield)
            {
                RechargeAmount = rechargeShield.RechargeAmount;
                EnergyCost = rechargeShield.EnergyCost;
            }
        }

        [Test]
        public void FullShield()
        {
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP);
            Verify.That(Bot.EP).Is(Bot.MaxEP);
            Verify.That(result).Is($"{Bot.Name} wants to recharge shield, but it's already full.");
        }

        [Test]
        public void HalfShield()
        {
            var damage = Bot.MaxSP / 2;
            Bot.TakeDamage(damage);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP - damage + RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield.");
        }

        [Test]
        public void NoShield()
        {
            Bot.TakeDamage(Bot.MaxSP);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield.");
        }

        [Test]
        public void NoShieldNoEnergy()
        {
            Bot.TakeDamage(Bot.MaxSP);
            Bot.DrainEnergy(Bot.MaxEP);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(0);
            Verify.That(Bot.EP).Is(0);
            Verify.That(result).Is($"{Bot.Name} does not have enough energy to recharge shield.");
        }
    }
}