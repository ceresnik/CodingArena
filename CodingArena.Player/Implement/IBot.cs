namespace CodingArena.Player.Implement
{
    public interface IBot
    {
        string Name { get; }

        IBotAI AI { get; }
    }
}