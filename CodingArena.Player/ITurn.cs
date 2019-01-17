using System.Collections.Generic;

namespace CodingArena.Player
{
    public interface ITurn
    {
        IRobot MyRobot { get; }

        IReadOnlyCollection<IEnemy> Enemies { get; }

        IBattlefield Battlefield { get; }
    }
}