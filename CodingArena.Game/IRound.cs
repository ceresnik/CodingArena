using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal interface IRound
    {
        Task<RoundResult> StartAsync(ICollection<Automata> mechWarriors, Battlefield battlefield);
    }
}