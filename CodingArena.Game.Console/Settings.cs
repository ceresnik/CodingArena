using System;
using System.ComponentModel.Composition;
using System.Configuration;

namespace CodingArena.Game.Console
{
    [Export(typeof(ISettings))]
    public class Settings : ISettings
    {
        public int BattlefieldWidth
        {
            get => int.Parse(ConfigurationManager.AppSettings["BattlefieldWidth"]);
            set => ConfigurationManager.AppSettings["BattlefieldWidth"] = value.ToString();
        }

        public int BattlefieldHeight
        {
            get => int.Parse(ConfigurationManager.AppSettings["BattlefieldHeight"]);
            set => ConfigurationManager.AppSettings["BattlefieldHeight"] = value.ToString();
        }

        public int MaxRounds
        {
            get => int.Parse(ConfigurationManager.AppSettings["MaxRounds"]);
            set => ConfigurationManager.AppSettings["MaxRounds"] = value.ToString();
        }

        public int MaxTurns
        {
            get => int.Parse(ConfigurationManager.AppSettings["MaxTurns"]);
            set => ConfigurationManager.AppSettings["MaxTurns"] = value.ToString();
        }

        public TimeSpan NextRoundDelay
        {
            get
            {
                int totalSeconds = int.Parse(ConfigurationManager.AppSettings["NextRoundDelayInSeconds"]);
                return new TimeSpan(0, 0, 0, totalSeconds);
            }
            set => ConfigurationManager.AppSettings["NextRoundDelayInSeconds"] = ((int)value.TotalSeconds).ToString();
        }

        public TimeSpan NextTurnActionDelay
        {
            get
            {
                int totalMilliseconds = int.Parse(ConfigurationManager.AppSettings["NextTurnActionDelayInMilliseconds"]);
                return new TimeSpan(0, 0, 0, 0, totalMilliseconds);
            }
            set => ConfigurationManager.AppSettings["NextTurnActionDelayInMilliseconds"] = ((int)value.TotalMilliseconds).ToString();
        }

        public int MaxHP
        {
            get => int.Parse(ConfigurationManager.AppSettings["MaxHP"]);
            set => ConfigurationManager.AppSettings["MaxHP"] = value.ToString();
        }

        public int MaxSP
        {
            get => int.Parse(ConfigurationManager.AppSettings["MaxSP"]);
            set => ConfigurationManager.AppSettings["MaxSP"] = value.ToString();
        }

        public int MaxEP
        {
            get => int.Parse(ConfigurationManager.AppSettings["MaxEP"]);
            set => ConfigurationManager.AppSettings["MaxEP"] = value.ToString();
        }
    }
}