using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IMovableObject
    {
        bool MoveTo(IBattlefieldPlace newPlace);
    }
}