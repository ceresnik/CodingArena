using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using static System.Console;

namespace CodingArena.Game.Console
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private Dictionary<string, int> Winners { get; set; }
        private IList<Bot> Bots { get; set; }
        public Dictionary<Bot, string> Actions { get; }
        private IBattlefield Battlefield { get; set; }

        public Output()
        {
            CursorVisible = false;
            Actions = new Dictionary<Bot, string>();
        }

        public void StartRound()
        {
            Actions.Clear();
            Update();
        }

        public void NextRoundIn(TimeSpan delayForNextRound)
        {
            Bots = new List<Bot>();
        }

        public void SetBattlefield(IBattlefield battlefield) => Battlefield = battlefield;

        public void NoBotsQualified() => Qualified(new List<Bot>());

        public void Qualified(Bot bot) => Qualified(new List<Bot> { bot });

        public void Qualified(IList<Bot> bots)
        {
            Bots = bots;
            Update();
        }

        public void TurnAction(Bot bot, string message)
        {
            if (Actions.ContainsKey(bot))
            {
                Actions[bot] = message;
            }
            else
            {
                Actions.Add(bot, message);
            }
            Update();
        }

        public void RoundResult(RoundResult roundResult)
        {
        }

        public void MatchResult(Dictionary<string, int> winners)
        {
            Winners = winners;
            Update();
        }

        public void Error(string message)
        {
            var previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ForegroundColor = previousColor;
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
            if (Winners != null)
            {
                int number = 1;
                foreach (var keyValuePair in Winners.OrderByDescending(pair => pair.Value))
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

            if (Bots != null)
            {
                if (Bots.Any())
                {
                    foreach (var bot in Bots)
                    {
                        row++;
                        DisplayRow(row, DisplayBot(bot));
                    }
                }
                else
                {
                    row++;
                    DisplayRow(row, "No bots qualified.");
                }
            }

            row++;
            FullRow(row, "=");
            CursorTop = row;
            CursorLeft = 1;
            WriteLine(" Actions ");

            if (Actions != null)
            {
                foreach (var action in Actions)
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

        private string DisplayBot(Bot bot)
        {
            string position = "";
            if (Battlefield != null)
            {
                var place = Battlefield[bot];
                position = $"[X: {place.X,2}, Y: {place.Y,2}]";
            }
            return $"  * {bot.Name,-30} " +
                   $"[HP: {bot.Health,3:F0}% SP: {bot.Shield,3:F0}% EP: {bot.Energy,3:F0}%] " +
                   position;
        }
    }
}