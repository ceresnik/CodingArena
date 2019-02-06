namespace CodingArena.Game
{
    public class Score
    {
        internal Score(string botName)
        {
            BotName = botName;
        }

        public string BotName { get; }
    }
}