using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IMovableObject
    {
        bool CanMoveTo(IBattlefieldPlace newPlace);
        bool MoveTo(IBattlefieldPlace newPlace);
    }
}