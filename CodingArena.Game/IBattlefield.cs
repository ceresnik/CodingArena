using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IBattlefield : IBattlefieldView
    {
        IBattlefieldPlace this[IBattleBot battleBot] { get; }
        void Set(IBattleBot battleBot, int newX, int newY);
    }
}