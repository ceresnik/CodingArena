using System;

namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeShield : ITurnAction
    {
        internal RechargeShield(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Value is less then zero.");
            RechargeAmount = amount;
            EnergyCost = amount;
        }

        public int EnergyCost { get; }

        public int RechargeAmount { get; }
    }
}