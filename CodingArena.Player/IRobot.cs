using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IRobot : IBattlefieldObject
    {
        int MaxHealthPoints { get; }
        int HealthPoints { get; }
        double HealthPercentage { get; }
        int MaxShieldPoints { get; }
        int ShieldPoints { get; }
        double ShieldPercentage { get; }
    }
}