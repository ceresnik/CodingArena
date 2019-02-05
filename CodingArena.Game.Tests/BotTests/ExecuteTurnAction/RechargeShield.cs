﻿using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class RechargeShield : TestFixture
    {
        private int RechargeAmount { get; set; }
        private int EnergyCost { get; set; }

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
            Bot.ExecuteTurnAction();
            Verify.That(Bot.SP).Is(Bot.MaxSP);
            Verify.That(Bot.EP).Is(Bot.MaxEP);
        }

        [Test]
        public void HalfShield()
        {
            var damage = Bot.MaxSP / 2;
            Bot.TakeDamage(damage);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.SP).Is(Bot.MaxSP - damage + RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
        }

        [Test]
        public void NoShield()
        {
            Bot.TakeDamage(Bot.MaxSP);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.SP).Is(RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
        }

        [Test]
        public void NoShieldNoEnergy()
        {
            Bot.TakeDamage(Bot.MaxSP);
            Bot.DrainEnergy(Bot.MaxEP);
            Bot.ExecuteTurnAction();
            Verify.That(Bot.SP).Is(0);
            Verify.That(Bot.EP).Is(0);
        }
    }
}