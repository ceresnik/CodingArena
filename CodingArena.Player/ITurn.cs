using System.Collections.Generic;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface ITurn
    {
        IMyRobot MyRobot { get; }

        IReadOnlyCollection<IEnemy> Enemies { get; }

        IBattlefield Battlefield { get; }
    }
}