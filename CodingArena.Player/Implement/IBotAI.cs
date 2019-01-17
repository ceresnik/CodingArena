namespace CodingArena.Player.Implement
{
    public interface IBotAI
    {
        ITurnAction CreateTurnAction(ITurn turn);
    }
}