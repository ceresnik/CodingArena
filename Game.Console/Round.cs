using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Console
{
    internal class Round : IRound
    {
        public Task<RoundResult> StartRoundAsync(IEnumerable<IBot> bots, Battlefield battlefield)
        {
            return Task.FromResult(new RoundResult());
        }
    }
}