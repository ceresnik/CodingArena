using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player;
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

        public Task<RoundResult> StartAsync(ICollection<IBot> bots, IBattlefield battlefield)
        {
            if (bots.Any())
            {
                textWriter.WriteLine("Bots qualified:");
                foreach (var bot in bots)
                {
                    textWriter.WriteLine(bot.Name);
                }

                int maxTurns = 100;
                for (int i = 0; i < maxTurns; i++)
                {
                    
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