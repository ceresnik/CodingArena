using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Console
{
    internal interface IRound
    {
        Task<RoundResult> StartRoundAsync(ICollection<IBot> bots, Battlefield battlefield);
    }
}