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
    }

    public interface ISettings
    {
        Size BattlefieldSize { get; set; }
    }
}