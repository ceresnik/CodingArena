using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Game.Console
{
    internal class Round : IRound
    {
        private readonly TextWriter textWriter;

        public Round(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public Task<RoundResult> StartRoundAsync(IEnumerable<IBot> bots, Battlefield battlefield)
        {
            bots.OnEmpty(() => textWriter.WriteLine("No bots found."));
            return Task.FromResult(new RoundResult());
        }
    }
}