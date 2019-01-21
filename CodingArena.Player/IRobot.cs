using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IRobot : IBattlefieldObject
    {
        int MaxHP { get; }
        int HP { get; }
        double HPPercentage { get; }
        int MaxSP { get; }
        int SP { get; }
        double SPPercentage { get; }
    }
}