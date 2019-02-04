using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IBotState
    {
        string Name { get; }
        float Shield { get; }
        float Energy { get; }
        float Health { get; }
        IBattlefieldPlace Position { get; }
    }
}