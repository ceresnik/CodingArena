namespace CodingArena.Player
{
    public interface IBotState
    {
        IValueState Health { get; }
        IValueState Shield { get; }
        IValueState Energy { get; }
    }
}