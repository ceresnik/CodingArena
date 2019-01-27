using System;
using System.ComponentModel.Composition;
using System.Configuration;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    [Export(typeof(ISettings))]
    internal class DefaultSettings : ISettings
    {
        public Size BattlefieldSize
        {
            get
            {
                int width = int.Parse(ConfigurationManager.AppSettings["BattlefieldWidth"]);
                int height = int.Parse(ConfigurationManager.AppSettings["BattlefieldHeight"]);
                return new Size(width, height);
            }
            set
            {
                ConfigurationManager.AppSettings["BattlefieldWidth"] = value.Width.ToString();
                ConfigurationManager.AppSettings["BattlefieldHeight"] = value.Height.ToString();
            }
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
    }
}