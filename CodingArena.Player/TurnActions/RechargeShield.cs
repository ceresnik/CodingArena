namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeShield : ITurnAction
    {
        internal RechargeShield()
        {
        }

        public int EnergyCost => 20;

        public int RechargeAmount => 20;
    }
}