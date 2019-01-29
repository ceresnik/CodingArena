using CodingArena.Player.TurnActions;

namespace CodingArena.Game
{
    internal class MalfunctionTurnAction : ITurnAction
    {
        public MalfunctionTurnAction(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public int EnergyCost => 0;
    }
}