using System;

namespace CodingArena.Game
{
    public class Score
    {
        internal Score(string botName, int kills, int deaths)
        {
            BotName = botName ?? throw new ArgumentNullException(nameof(botName));
            Kills = kills;
            Deaths = deaths;
        }

        public string BotName { get; }
        public int Kills { get; }
        public int Deaths { get; }
    }
}