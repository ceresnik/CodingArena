using System.Collections.Generic;
using System.Threading.Tasks;
using CodingArena.Player;

namespace CodingArena.Game
{
    internal interface IRound
    {
        Task<RoundResult> StartRoundAsync(ICollection<IBot> bots, IBattlefield battlefield);
    }
}