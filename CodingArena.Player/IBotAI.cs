namespace CodingArena.Player
{
    public interface IBotAI
    {
        ITurnAction CreateTurnAction(ITurn turn);
    }
}