using System.Collections.Generic;
using System.ComponentModel.Composition;
using CodingArena.Player.Battlefield;
using static System.Console;
using static System.ConsoleColor;
using static System.Linq.Enumerable;

namespace CodingArena.Game.Console
{
    [Export(typeof(INewOutput))]
    internal class NewOutput : INewOutput
    {
        private IGameNotifier Game { get; set; }
        private IMatchNotifier Match { get; set; }
        private IRoundNotifier Round { get; set; }
        private ITurnNotifier Turn { get; set; }
        private int MatchRow { get; set; }
        private int RoundRow { get; set; }
        private int TurnRow { get; set; }

        [ImportingConstructor]
        public NewOutput(ISettings settings)
        {
            Settings = settings;
            CursorVisible = false;
            MatchRow = 1;
        }

        public ISettings Settings { get; }

        public void Observe(IGameNotifier game)
        {
            Game = game;
            Game.MatchStarting += OnMatchStarting;
            Game.MatchStarted += OnMatchStarted;
        }

        private void OnMatchStarting(object sender, MatchEventArgs e)
        {
            Match = e.Match;
            Match.RoundStarting += OnRoundStarting;
            Match.RoundStarted += OnRoundStarted;
            Display(Match);
        }

        private void OnMatchStarted(object sender, MatchEventArgs e)
        {

        }

        private void OnRoundStarting(object sender, RoundEventArgs e)
        {
            Round = e.Round;
            Round.TurnStarting += OnTurnStarting;
            Round.TurnStarted += OnTurnStarted;
            Display(Round);
        }

        private void OnRoundStarted(object sender, RoundEventArgs e)
        {

        }

        private void OnTurnStarting(object sender, TurnEventArgs e)
        {
            Turn = e.Turn;
            Display(Turn);
        }

        private void OnTurnStarted(object sender, TurnEventArgs e)
        {

        }

        private void Display(IMatchNotifier match)
        {
            DisplayHeader(MatchRow, "Match");
            RoundRow = MatchRow + 1;
        }

        private void Display(IRoundNotifier round)
        {
            DisplayHeader(RoundRow, 
                $"Round ({round.Number} / {Settings.MaxRounds}) " +
                $"(Battlefield [{round.Battlefield.Width}x{round.Battlefield.Height}]) ");

            var row = RoundRow + 1;
            var botStates = round.BotStates.ToList();
            for (int i = 0; i < botStates.Count; i++)
            {
                var botState = botStates[i];
                Display(row + i, botState);
            }
            TurnRow = RoundRow + round.BotStates.Count() + 1;
        }

        private void Display(int row, IBotState botState)
        {
            string position = "";
            if (botState.Position != null)
            {
                position = $"[X: {botState.Position.X,2}, Y: {botState.Position.Y,2}]";
            }
            DisplayRow(row,
                $"  * {botState.Name,-30} " +
                $"[HP: {botState.Health,3:F0} % SP: {botState.Shield,3:F0} % EP: {botState.Energy,3:F0} %] " + 
                position);
        }

        private void Display(ITurnNotifier turn)
        {
            DisplayHeader(TurnRow,$"Turn ({turn.Number} / {Settings.MaxTurns})");
        }

        private void DisplayHeader(int rowIndex, string text)
        {
            FullRow(rowIndex, "=");
            CursorTop = rowIndex;
            CursorLeft = 1;
            WriteLine($" {text} ");
        }

        public void Error(string message)
        {
            var previousColor = ForegroundColor;
            ForegroundColor = Red;
            WriteLine(message);
            ForegroundColor = previousColor;
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
            WriteLine(string.Join("", Repeat(s, BufferWidth - 1)));
        }
    }
}