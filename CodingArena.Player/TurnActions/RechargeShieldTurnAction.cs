namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeShieldTurnAction : ITurnAction
    {
        internal RechargeShieldTurnAction()
        {
        }

        public int EnergyCost => 50;
    }
}