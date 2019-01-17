namespace CodingArena.Player.Battlefield
{
    public interface IBattlefieldPlace
    {
        bool IsEmpty { get; }
        IBattlefieldObject Object { get; }
    }
}