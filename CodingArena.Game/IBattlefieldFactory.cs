using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IBattlefieldFactory
    {
        IBattlefield Create();
    }
}