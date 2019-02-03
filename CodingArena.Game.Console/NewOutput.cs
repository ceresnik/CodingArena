using System.ComponentModel.Composition;
using static System.Console;

namespace CodingArena.Game.Console
{
    [Export(typeof(INewOutput))]
    internal class NewOutput : INewOutput
    {
        private IGameNotifier Game { get; set; }
        private IMatchNotifier Match { get; set; }
        private IRoundNotifier Round { get; set; }
        private ITurnNotifier Turn { get; set; }

        public void Observe(IGameNotifier game)
        {
            game.MatchStarting += OnMatchStarting;
            game.MatchStarted += OnMatchStarted;
        }

        private void OnMatchStarting(object sender, MatchEventArgs e)
        {
            Match = e.Match;
            Match.RoundStarting += OnRoundStarting;
            Match.RoundStarted += OnRoundStarted;
        }

        private void OnMatchStarted(object sender, MatchEventArgs e)
        {

        }

        private void OnRoundStarting(object sender, RoundEventArgs e)
        {
            Round = e.Round;
            Round.TurnStarting += OnTurnStarting;
            Round.TurnStarted += OnTurnStarted;
        }

        private void OnRoundStarted(object sender, RoundEventArgs e)
        {

        }

        private void OnTurnStarting(object sender, TurnEventArgs e)
        {
            Turn = e.Turn;
            WriteLine($"Turn: {Turn.Number}");
        }

        private void OnTurnStarted(object sender, TurnEventArgs e)
        {

        }
    }
}