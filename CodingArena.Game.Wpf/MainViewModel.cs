using System;
using System.Windows.Input;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    public class MainViewModel : Observable
    {
        private string myText;
        private IGame Game { get; set; }

        public MainViewModel()
        {
            StartCommand = new DelegateCommand(Start);
        }

        private void Start()
        {
            var container = ContainerFactory.Create();
            Game = container.GetExportedValue<IGame>();
            Game.MatchStarting += OnMatchStarting;
            Game.Start();
        }

        private void OnMatchStarting(object sender, EventArgs e)
        {
            myText = "Match Starting";
        }

        public string Text
        {
            get => myText;
            private set
            {
                if (value == myText) return;
                myText = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand { get; }
    }
}