namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeBattery : ITurnAction
    {
        internal RechargeBattery()
        {
        }

        public int EnergyCost => 3;

        public int RechargeAmount => 10;
    }
}