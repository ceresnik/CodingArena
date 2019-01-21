using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal class Round : IRound
    {
        private readonly TextWriter textWriter;

        public Round(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public Task<RoundResult> StartAsync(ICollection<Bot> bots, Battlefield battlefield)
        {
            if (bots == null) throw new ArgumentNullException(nameof(bots));
            if (battlefield == null) throw new ArgumentNullException(nameof(battlefield));

            var roundResult = new RoundResult();
            if (bots.Any())
            {
                textWriter.WriteLine("Bots qualified:");
                foreach (var bot in bots)
                {
                    textWriter.WriteLine(bot.Name);
                }

                if (bots.Count == 1)
                {
                    roundResult.Winner = bots.First().Name;
                }
                else
                {
                    int maxTurns = 100;
                    for (int i = 0; i < maxTurns; i++)
                    {
                        foreach (var bot in bots)
                        {
                            var enemies = bots.Except(new[] {bot}).ToList();                            
                            bot.Execute(enemies.Select(e => new Enemy(e.Name, e.State.Health, e.State.Shield)));
                        }
                    }

                    var aliveBots = bots.Where(b => b.State.Health.Actual > 0).ToList();
                    if (aliveBots.Count > 1)
                    {
                        Console.WriteLine($"No winner after {maxTurns} turns. Remaining bots found:");
                        aliveBots.ForEach(b => Console.WriteLine(b.Name));
                    }
                    else
                    {
                        roundResult.Winner = aliveBots.First().Name;
                    }
                }
            }
            else
            {
                textWriter.WriteLine("No bots found.");
            }

            if (roundResult.Winner != null)
            {
                Console.WriteLine($"Winner is {roundResult.Winner}");
            }

            return Task.FromResult(roundResult);
        }
    }
}