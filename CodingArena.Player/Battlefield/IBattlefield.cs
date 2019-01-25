namespace CodingArena.Player.Battlefield
{
    public interface IBattlefield
    {
        Size Size { get; }
        IBattlefieldPlace this[int x, int y] { get; }
        IBattlefieldPlace this[IBattlefieldObject battlefieldObject] { get; }
    }
}