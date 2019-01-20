using System.Collections.Generic;
using System.Threading.Tasks;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal interface IRound
    {
        Task<RoundResult> StartAsync(ICollection<IBot> bots, Battlefield battlefield);
    }
}