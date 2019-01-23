namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeBattery : ITurnAction
    {
        internal RechargeBattery()
        {
        }

        public int EnergyCost => 5;

        public int RechargeAmount => 20;
    }
}