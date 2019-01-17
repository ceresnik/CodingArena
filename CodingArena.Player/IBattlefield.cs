namespace CodingArena.Player
{
    public interface IBattlefield
    {
        IBattlefieldPlace this[int x, int y] { get; }
    }
}