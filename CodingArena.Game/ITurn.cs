namespace CodingArena.Game
{
    public interface ITurn
    {
        int Number { get; }
        ITurn StartTurn();
    }
}