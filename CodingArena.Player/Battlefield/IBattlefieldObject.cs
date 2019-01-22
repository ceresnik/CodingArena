namespace CodingArena.Player.Battlefield
{
    public interface IBattlefieldObject
    {
        string Name { get; }
        IBattlefieldPlace Position { get; }
    }
}