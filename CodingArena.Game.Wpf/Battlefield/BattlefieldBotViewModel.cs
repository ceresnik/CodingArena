using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Common;

namespace CodingArena.Game.Wpf.Battlefield
{
    internal class BattlefieldBotViewModel : ViewModel
    {
        private string myBotName;
        private int myX;
        private int myY;

        public BattlefieldBotViewModel(IBattleBot battleBot)
        {
            UpdateFrom(battleBot);
        }

        public string BotName
        {
            get => myBotName;
            private set
            {
                if (value == myBotName) return;
                myBotName = value;
                OnPropertyChanged();
            }
        }

        public int X
        {
            get => myX;
            private set
            {
                if (value == myX) return;
                myX = value;
                OnPropertyChanged();
            }
        }

        public int Y
        {
            get => myY;
            private set
            {
                if (value == myY) return;
                myY = value;
                OnPropertyChanged();
            }
        }

        public void UpdateFrom(IBattleBot bot)
        {
            BotName = bot.Name;
            X = bot.Position.X * 14;
            Y = 700 - bot.Position.Y * 14 - 14;
        }
    }
}