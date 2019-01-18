namespace CodingArena.Player
{
    public interface IMyRobot : IRobot
    {
        int MaxEnergyPoints { get; }
        int EnergyPoints { get; }
        double EnergyPercentage { get; }
    }
}