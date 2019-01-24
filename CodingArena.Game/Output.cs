using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using static System.Console;

namespace CodingArena.Game
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private Dictionary<string, int> winners;
        private IList<Bot> bots;
        private readonly Dictionary<Bot, string> actions;

        public Output()
        {
            CursorVisible = false;
            actions = new Dictionary<Bot, string>();
        }

        public void StartRound()
        {
            actions.Clear();
            Update();
        }

        public void NextRoundIn(TimeSpan delayForNextRound)
        { 
        }

        public void Battlefield(Battlefield battlefield)
        {
        }

        public void NoBotsQualified()
        {
        }

        public void Qualified(Bot bot) => Qualified(new List<Bot>{bot});

        public void Qualified(IList<Bot> bots)
        {
            this.bots = bots;
        }

        public void TurnAction(Bot bot, string message)
        {
            if (actions.ContainsKey(bot))
            {
                actions[bot] = message;
            }
            else
            {
                actions.Add(bot, message);
            }
        }

        public void RoundResult(RoundResult roundResult)
        {
        }

        public void MatchResult(Dictionary<string, int> winners)
        {
            this.winners = winners;
            Update();
        }

        private void Update()
        {
            Clear();
            int row = 0;
            DisplayRow(0, "CodingArena");
            row++;
            FullRow(row, "=");
            CursorTop = row;
            CursorLeft = 1;
            WriteLine(" Match ");
            if (winners != null)
            {
                int number = 1;
                foreach (var keyValuePair in winners.OrderByDescending(pair => pair.Value))
                {
                    row++;
                    DisplayRow(row, $" {number}. {keyValuePair.Key,-30} [{keyValuePair.Value}]");
                    number++;
                }
            }

            row++;
            FullRow(row, "=");
            CursorTop = row;
            CursorLeft = 1;
            WriteLine(" Round ");

            if (bots != null)
            {
                foreach (var bot in bots)
                {
                    row++;
                    DisplayRow(row, DisplayBot(bot));
                }
            }

            row++;
            FullRow(row, "=");
            CursorTop = row;
            CursorLeft = 1;
            WriteLine(" Actions ");

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    row++;
                    DisplayRow(row, $"{action.Value}");
                }
            }
        }

        private void DisplayRow(int row, string message)
        {
            FullRow(row, " ");
            CursorTop = row;
            CursorLeft = 0;
            WriteLine(message);
        }

        private void FullRow(int row, string s)
        {
            CursorTop = row;
            CursorLeft = 0;
            WriteLine(string.Join("", Enumerable.Repeat(s, BufferWidth - 1)));
        }

        private static string DisplayBot(Bot bot)
        {
            string position = "";
            if (bot.Position != null)
            {
                position = $"[X: {bot.Position.X,2}, Y: {bot.Position.Y,2}]";
            }
            return $"  * {bot.Name,-30} " +
                   $"[HP: {bot.Health,3:F0} SP: {bot.Shield,3:F0} EP: {bot.Energy,3:F0}] " +
                   position;
        }
    }
}