namespace CodingArena.Player
{
    public interface IEnemy
    {
        string Name { get; }

        int HealthPoints { get; }

        double HealthPercentage { get; }

        int ShieldPoints { get; }

        double ShieldPercentage { get; }
    }
}