namespace CodingArena.Player
{
    public interface IBot
    {
        string Name { get; }

        IBotAI AI { get; }
    }
}