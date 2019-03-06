namespace CodingArena.Game.Entities
{
    public class Score
    {
        public string BotName { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }

        public override string ToString() => $"BotName: {BotName}, Kills: {Kills}, Deaths: {Deaths}";
    }
}