namespace CodingArena.Player
{
    public interface IValueState
    {
        int Max { get; }
        int Actual { get; }
        double Percentage { get; }
    }
}