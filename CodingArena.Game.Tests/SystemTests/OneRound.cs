using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using NUnit.Framework;

namespace CodingArena.Game.Tests.SystemTests
{
    internal class OneRound
    {
        private TextWriter Output { get; set; }
        private Battlefield Battlefield { get; set; }

        [Test]
        public async Task TwoAttackerAIs()
        {
            Console.WriteLine("Starting Coding Arena Game...");
            try
            {
                var config = new GameConfiguration();
                Output = Console.Out;
                var engine = new GameEngine(config, Output);
                IBattlefieldSize size = config.BattlefieldSize;
                var match = engine.CreateMatch();

                Battlefield = new Battlefield(size.Width, size.Height);
                Output.WriteLine($"Battlefield initialized to width:{size.Width} height:{size.Height}.");
                var bots = new Collection<Bot>
                {
                    new Bot(Output, new AttackerAI("BotA"), Battlefield),
                    new Bot(Output, new AttackerAI("BotB"), Battlefield),
                };
                var round = await match.CreateRoundAsync();
                var roundResult = await round.StartAsync(bots, Battlefield);
                roundResult.DisplayTo(Output);
            }
            catch (Exception e)
            {
                Console.WriteLine("Game is broken.");
                Console.WriteLine($"Error message: {e}");
            }
        }
    }

    internal class AttackerAI : IBotAI
    {
        public AttackerAI(string botName)
        {
            BotName = botName;
        }

        public string BotName { get; }
        public ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield)
        {
            if (enemies.Any())
            {
                if (ownBot.Energy < 10)
                {
                    return TurnAction.Recharge.Battery();
                }
                if (ownBot.Shield < 50)
                {
                    return TurnAction.Recharge.Shield();
                }
                var closestEnemy = FindClosestEnemy(ownBot, enemies);

                var minAttackDistance = 6;
                if (ownBot.Position.DistanceTo(closestEnemy.Position) < minAttackDistance)
                    return TurnAction.Attack(closestEnemy);

                var fromPlace = battlefield[ownBot];
                var toPlace = battlefield[closestEnemy];
                return TurnAction.Move.Towards(fromPlace, toPlace);
            }

            return TurnAction.Idle();
        }

        private IEnemy FindClosestEnemy(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies)
        {
            var closestEnemy = enemies.First();
            foreach (var enemy in enemies.Except(new[] { closestEnemy }))
            {
                if (ownBot.Position.DistanceTo(enemy.Position) < ownBot.Position.DistanceTo(closestEnemy.Position))
                {
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}