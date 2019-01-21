using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game
{
    internal class Round : IRound
    {
        private readonly TextWriter textWriter;
        private readonly IDictionary<string, IMyRobot> robots;

        public Round(TextWriter textWriter)
        {
            this.textWriter = textWriter;
            this.robots = new Dictionary<string, IMyRobot>();
        }

        public Task<RoundResult> StartAsync(ICollection<Automata> mechWarriors, Battlefield battlefield)
        {
            if (mechWarriors == null) throw new ArgumentNullException(nameof(mechWarriors));
            if (battlefield == null) throw new ArgumentNullException(nameof(battlefield));

            var roundResult = new RoundResult();
            if (mechWarriors.Any())
            {
                textWriter.WriteLine("Bots qualified:");
                foreach (var bot in mechWarriors)
                {
                    textWriter.WriteLine(bot.Name);
                    int maxEP = 1000;
                    int maxHP = 1000;
                    int maxSP = 1000;
                    robots.Add(bot.Name, new MyRobot(bot.Name, maxEP, maxEP, maxHP, maxHP, maxSP, maxSP));
                }

                if (mechWarriors.Count == 1)
                {
                    roundResult.Winner = mechWarriors.First().Name;
                }
                else
                {
                    int maxTurns = 100;
                    for (int i = 0; i < maxTurns; i++)
                    {
                        foreach (var mechWarrior in mechWarriors)
                        {
                            var enemyBots = mechWarriors.Except(new[] {mechWarrior});
                            var enemies = new List<IEnemy>();
                            foreach (var enemyBot in enemyBots)
                            {
                                var robot = robots[enemyBot.Name];
                                var enemy = new Enemy(
                                    enemyBot.Name,
                                    robot.MaxHP, robot.HP,
                                    robot.MaxSP, robot.SP);
                                enemies.Add(enemy);
                            }

                            var thisRobot = robots[mechWarrior.Name];
                            var turn = new Turn(thisRobot, enemies, battlefield);
                            mechWarrior.Execute(turn);
                        }
                    }

                    if (robots.Values.Count(r => r.HP > 0) > 0)
                    {
                        Console.WriteLine("No winner after 100 turns. Remaining bots found:");
                        foreach (var robot in robots.Where(r => r.Value.HP > 0))
                        {
                            Console.WriteLine(robot.Key);
                        }
                    }
                    else
                    {
                        foreach (var robot in robots.Where(r => r.Value.HP > 0))
                        {
                            roundResult.Winner = robot.Key;
                            break;
                        }
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