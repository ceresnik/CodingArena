namespace CodingArena.Player
{
    public interface IBattlefield
    {
        IBattlefieldSize Size { get; }
        IBattlefieldPlace this[int x, int y] { get; }
    }
}