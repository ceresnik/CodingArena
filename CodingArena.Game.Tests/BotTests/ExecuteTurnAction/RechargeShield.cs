using System;
using CodingArena.Game.Tests.Verification;
using CodingArena.Player.TurnActions;
using NUnit.Framework;
using System.Collections.Generic;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Tests.BotTests.ExecuteTurnAction
{
    internal class RechargeShield : TestFixture
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            BotAI.TurnAction = TurnAction.Recharge.Shield(10);
            if (BotAI.TurnAction is Player.TurnActions.RechargeShield rechargeShield)
            {
                RechargeAmount = rechargeShield.RechargeAmount;
                EnergyCost = rechargeShield.EnergyCost;
            }
        }

        [Test]
        public void RechargeAmount100_Missing100SP()
        {
            BotAI.TurnAction = TurnAction.Recharge.Shield(100);
            if (BotAI.TurnAction is Player.TurnActions.RechargeShield rechargeShield)
            {
                RechargeAmount = rechargeShield.RechargeAmount;
                EnergyCost = rechargeShield.EnergyCost;
            }
            Bot.TakeDamage(RechargeAmount);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield by {RechargeAmount} SP.");
        }

        [Test]
        public void RechargeAmount100_Missing200SP()
        {
            BotAI.TurnAction = TurnAction.Recharge.Shield(100);
            if (BotAI.TurnAction is Player.TurnActions.RechargeShield rechargeShield)
            {
                RechargeAmount = rechargeShield.RechargeAmount;
                EnergyCost = rechargeShield.EnergyCost;
            }
            Bot.TakeDamage(RechargeAmount * 2);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP - RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield by {RechargeAmount} SP.");
        }

        [Test]
        public void RechargeAmount100_Missing50SP()
        {
            BotAI.TurnAction = TurnAction.Recharge.Shield(100);
            if (BotAI.TurnAction is Player.TurnActions.RechargeShield rechargeShield)
            {
                RechargeAmount = rechargeShield.RechargeAmount;
                EnergyCost = rechargeShield.EnergyCost;
            }
            Bot.TakeDamage(RechargeAmount / 2);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield by {RechargeAmount / 2} SP.");
        }

        [Test]
        public void RechargeAmount100_Energy50EP()
        {
            BotAI.TurnAction = TurnAction.Recharge.Shield(100);
            Bot.TakeDamage(100);
            Bot.DrainEnergy(Bot.MaxEP - 50);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(Bot.MaxSP - 50);
            Verify.That(Bot.EP).Is(0);
            Verify.That(result).Is($"{Bot.Name} recharges shield by {50} SP.");
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
            Verify.That(result).Is($"{Bot.Name} recharges shield by 10 SP.");
        }

        [Test]
        public void NoShield()
        {
            Bot.TakeDamage(Bot.MaxSP);
            var result = Bot.ExecuteTurnAction(new List<IBattleBot>());
            Verify.That(Bot.SP).Is(RechargeAmount);
            Verify.That(Bot.EP).Is(Bot.MaxEP - EnergyCost);
            Verify.That(result).Is($"{Bot.Name} recharges shield by 10 SP.");
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