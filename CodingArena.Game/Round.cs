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

        public Task<RoundResult> StartAsync(ICollection<IBot> bots, Battlefield battlefield)
        {
            var roundResult = new RoundResult();
            if (bots.Any())
            {
                textWriter.WriteLine("Bots qualified:");
                foreach (var bot in bots)
                {
                    textWriter.WriteLine(bot.Name);
                    int maxEP = 1000;
                    int maxHP = 1000;
                    int maxSP = 1000;
                    robots.Add(bot.Name, new MyRobot(maxEP, maxEP, maxHP, maxHP, maxSP, maxSP));
                }

                if (bots.Count == 1)
                {
                    roundResult.Winner = bots.First().Name;
                }
                int maxTurns = 100;
                for (int i = 0; i < maxTurns; i++)
                {
                    foreach (var bot in bots)
                    {
                        var enemyBots = bots.Except(new[] {bot});
                        var enemies = new List<IEnemy>();
                        foreach (var enemyBot in enemyBots)
                        {
                            var robot = robots[enemyBot.Name];
                            var enemy = new Enemy(
                                enemyBot.Name, 
                                robot.MaxHealthPoints, robot.HealthPoints, 
                                robot.MaxShieldPoints, robot.ShieldPoints);
                            enemies.Add(enemy);
                        }

                        var thisRobot = robots[bot.Name];
                        var turn = new Turn(thisRobot, enemies, battlefield);
                        var turnAction = bot.AI.CreateTurnAction(turn);
                        if (turnAction is MoveTurnAction move)
                        {
                            // TODO
                        }
                    }
                }

                if (robots.Values.Count(r => r.HealthPoints > 0) > 0)
                {
                    Console.WriteLine("No winner after 100 turns. Remaining bots found:");
                    foreach (var robot in robots.Where(r => r.Value.HealthPoints > 0))
                    {
                        Console.WriteLine(robot.Key);
                    }
                }
                else
                {
                    foreach (var robot in robots.Where(r => r.Value.HealthPoints > 0))
                    {
                        roundResult.Winner = robot.Key;
                        break;
                    }
                }
            }
            else
            {
                textWriter.WriteLine("No bots found.");
            }

            return Task.FromResult(roundResult);
        }
    }
}