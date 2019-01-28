namespace CodingArena.Game.Console
{
    public interface ITurn
    {
        int Number { get; }
        ITurn StartTurn();
    }
}