using System;

namespace CodingArena.Game.Entities
{
    public class Score
    {
        public Score(string botName)
        {
            BotName = botName ?? throw new ArgumentNullException(nameof(botName));
        }

        public string BotName { get; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
    }
}