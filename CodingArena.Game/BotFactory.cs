using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingArena.Game.Console
{
    internal class BotFactory
    {
        public virtual ICollection<IBot> CreateBots() => new Collection<IBot>();
    }

    internal class TestBotFactory : BotFactory
    {
        public override ICollection<IBot> CreateBots()
        {
            return new List<IBot>
            {
                new SimpleBot("BotA"),
                new SimpleBot("BotB"),
                new SimpleBot("BotC"),
            };
        }
    }

    internal class SimpleBot : IBot
    {
        public SimpleBot(string name)
        {
            Name = name;
            MaxHealthPoints = 1000;
            HealthPoints = MaxHealthPoints;
        }

        public string Name { get; }
        public int MaxHealthPoints { get; }
        public int HealthPoints { get; }

        public double HealthPercentage => HealthPoints * 100 / (double) MaxHealthPoints;

        public int MaxShieldPoints { get; }
        public int ShieldPoints { get; }
        public double ShieldPercentage { get; }
        public BattlefieldPosition Position { get; }
    }
}