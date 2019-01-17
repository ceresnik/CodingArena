using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IRobot : IBattlefieldObject
    {
        int HealthPoints { get; }
        double HealthPercentage { get; }
        int ShieldPoints { get; }
        double ShieldPercentage { get; }
    }
}