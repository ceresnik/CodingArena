using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal class Round : IRound
    {
        private readonly TextWriter textWriter;

        public Round(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public Task<RoundResult> StartRoundAsync(ICollection<IBot> bots, IBattlefield battlefield)
        {
            if (bots.Any())
            {
                textWriter.WriteLine("Bots qualified:");
                foreach (var bot in bots)
                {
                    textWriter.WriteLine(bot.Name);
                }
            }
            else
            {
                textWriter.WriteLine("No bots found.");
            }
            return Task.FromResult(new RoundResult());
        }
    }
}