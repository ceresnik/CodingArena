namespace CodingArena.Player
{
    public interface IRobot
    {
        int HealthPoints { get; }
        double HealthPercentage { get; }
        int ShieldPoints { get; }
        double ShieldPercentage { get; }
    }
}