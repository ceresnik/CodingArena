using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Game.Console
{
    internal class BotFactory
    {
        public virtual ICollection<IBot> CreateBots(Battlefield battlefield) => 
            new Collection<IBot>();
    }

    internal class TestBotFactory : BotFactory
    {
        public override ICollection<IBot> CreateBots(Battlefield battlefield)
        {
            var random = new Random((int) DateTime.Now.Ticks);
            return new List<IBot>
            {
                new SeekAndDestroyBot("BotA", GenerateRandomPosition(battlefield, random)),
                new SeekAndDestroyBot("BotB", GenerateRandomPosition(battlefield, random)),
                new SeekAndDestroyBot("BotC", GenerateRandomPosition(battlefield, random)),
            };
        }

        private static BattlefieldPosition GenerateRandomPosition(Battlefield battlefield, Random random)
        {
            var x = random.Next(battlefield.Size.Width);
            var y = random.Next(battlefield.Size.Height);
            return new BattlefieldPosition(x, y, battlefield);
        }
    }

    internal class SeekAndDestroyBot : IBot
    {
        public SeekAndDestroyBot(string name, BattlefieldPosition position)
        {
            Name = name;
            MaxHealthPoints = 1000;
            HealthPoints = MaxHealthPoints;
            MaxShieldPoints = 1000;
            ShieldPoints = MaxShieldPoints;
            Position = position;
        }

        public string Name { get; }

        public int MaxHealthPoints { get; }

        public int HealthPoints { get; }

        public double HealthPercentage => HealthPoints * 100 / (double) MaxHealthPoints;

        public int MaxShieldPoints { get; }

        public int ShieldPoints { get; }

        public double ShieldPercentage => ShieldPoints * 100 / (double)MaxShieldPoints;

        public BattlefieldPosition Position { get; }
    }
}