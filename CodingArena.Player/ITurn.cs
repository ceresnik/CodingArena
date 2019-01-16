using System.Collections.Generic;

namespace CodingArena.Player
{
    public interface ITurn
    {
        IReadOnlyCollection<IEnemy> Enemies { get; }
    }
}