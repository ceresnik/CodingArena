using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal class Round : IRound
    {
        private TextWriter Output { get; }

        public Round(TextWriter output)
        {
            Output = output;
        }

        public Task<RoundResult> StartAsync(ICollection<Bot> bots, Battlefield battlefield)
        {
            return Task.FromResult(new RoundResult());
        }
    }
}