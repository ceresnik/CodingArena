namespace CodingArena.Player.Battlefield
{
    public interface IBattlefieldPlace
    {
        int X { get; }
        int Y { get; }
        bool IsEmpty { get; }
        IBattlefieldObject Object { get; }
        double DistanceTo(int x, int y);
        double DistanceTo(IBattlefieldPlace place);
    }
}