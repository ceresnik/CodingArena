namespace CodingArena.Player
{
    public interface IMyRobot : IRobot
    {
        int MaxEnergy { get; }
        int RemainingEnergy { get; }
        double EnergyPercentage { get; }
    }
}