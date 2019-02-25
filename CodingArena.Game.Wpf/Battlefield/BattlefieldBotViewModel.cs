using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Common;
using System.Windows;

namespace CodingArena.Game.Wpf.Battlefield
{
    internal class BattlefieldBotViewModel : ViewModel
    {
        private string myBotName;
        private int myX;
        private int myY;
        private string myImageSource;
        private int myHP;
        private int myMaxHP;
        private int myMaxSP;
        private int mySP;
        private int myMaxEP;
        private int myEP;
        private Visibility myProgressBarVisibility;

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

        public string ImageSource
        {
            get => myImageSource;
            set
            {
                if (value == myImageSource) return;
                myImageSource = value;
                OnPropertyChanged();
            }
        }

        public int HP
        {
            get => myHP;
            set
            {
                if (value == myHP) return;
                myHP = value;
                OnPropertyChanged();
            }
        }

        public int MaxHP
        {
            get => myMaxHP;
            set
            {
                if (value == myMaxHP) return;
                myMaxHP = value;
                OnPropertyChanged();
            }
        }

        public int MaxSP
        {
            get => myMaxSP;
            set
            {
                if (value == myMaxSP) return;
                myMaxSP = value;
                OnPropertyChanged();
            }
        }

        public int SP
        {
            get => mySP;
            set
            {
                if (value == mySP) return;
                mySP = value;
                OnPropertyChanged();
            }
        }

        public int MaxEP
        {
            get => myMaxEP;
            set
            {
                if (value == myMaxEP) return;
                myMaxEP = value;
                OnPropertyChanged();
            }
        }

        public int EP
        {
            get => myEP;
            set
            {
                if (value == myEP) return;
                myEP = value;
                OnPropertyChanged();
            }
        }

        public Visibility ProgressBarVisibility
        {
            get => myProgressBarVisibility;
            set
            {
                if (value == myProgressBarVisibility) return;
                myProgressBarVisibility = value;
                OnPropertyChanged();
            }
        }

        public void UpdateFrom(IBattleBot bot)
        {
            BotName = bot.Name;
            X = bot.Position.X * 14;
            Y = 700 - bot.Position.Y * 14 - 14;
            ImageSource = bot.HP > 0 ? "robot.png" : "scrap.png";
            MaxHP = bot.MaxHP;
            HP = bot.HP;
            MaxSP = bot.MaxSP;
            SP = bot.SP;
            ProgressBarVisibility = HP > 0 ? Visibility.Visible : Visibility.Hidden;
        }
    }
}