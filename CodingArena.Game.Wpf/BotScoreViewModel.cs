using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    internal class BotScoreViewModel
    {
        private Score Score { get; }

        public BotScoreViewModel(Score score)
        {
            Score = score;
        }

        public string BotName => Score.BotName;

        public int Kills => Score.Kills;

        public int Deaths => Score.Deaths;
    }
}