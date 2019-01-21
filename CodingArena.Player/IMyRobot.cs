namespace CodingArena.Player
{
    public interface IMyRobot : IRobot
    {
        int MaxEP { get; }
        int EP { get; }
        double EPPercentage { get; }
    }
}