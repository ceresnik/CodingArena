using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Battlefield;
using CodingArena.Game.Wpf.Common;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingArena.Game.Wpf
{
    [Export(typeof(IMainViewModel))]
    internal class MainViewModel : Observable, IMainViewModel
    {
        private IMainView View { get; }
        private string myMatchText;
        private string myTurnText;
        private int myTurnNumber;
        private int myMaxTurns;
        private int myBattlefieldWidth;
        private int myBattlefieldHeight;
        private string myBattlefieldText;
        private int myRoundNumber;
        private int myMaxRounds;
        private string myNextRoundIn;
        private BattlefieldViewModel myBattlefieldViewModel;

        [ImportingConstructor]
        public MainViewModel(IMainView view)
        {
            View = view;
            View.DataContext = this;
            StartCommand = new DelegateCommand(async () => await StartAsync());
            BotStates = new ObservableCollection<BotStateViewModel>();
            BotScores = new ObservableCollection<BotScoreViewModel>();
            RoundBotScores = new ObservableCollection<BotScoreViewModel>();
        }

        public BattlefieldViewModel BattlefieldViewModel
        {
            get => myBattlefieldViewModel;
            set
            {
                if (Equals(value, myBattlefieldViewModel)) return;
                myBattlefieldViewModel = value;
                OnPropertyChanged();
            }
        }

        public IGame Game { get; set; }

        public string MatchText
        {
            get => myMatchText;
            set
            {
                if (value == myMatchText) return;
                myMatchText = value;
                OnPropertyChanged();
            }
        }

        public int RoundNumber
        {
            get => myRoundNumber;
            set
            {
                if (value == myRoundNumber) return;
                myRoundNumber = value;
                OnPropertyChanged();
            }
        }

        public int MaxRounds
        {
            get => myMaxRounds;
            set
            {
                if (value == myMaxRounds) return;
                myMaxRounds = value;
                OnPropertyChanged();
            }
        }

        public int BattlefieldWidth
        {
            get => myBattlefieldWidth;
            set
            {
                if (value == myBattlefieldWidth) return;
                myBattlefieldWidth = value;
                OnPropertyChanged();
            }
        }

        public int BattlefieldHeight
        {
            get => myBattlefieldHeight;
            set
            {
                if (value == myBattlefieldHeight) return;
                myBattlefieldHeight = value;
                OnPropertyChanged();
            }
        }

        public string BattlefieldText
        {
            get => myBattlefieldText;
            set
            {
                if (value == myBattlefieldText) return;
                myBattlefieldText = value;
                OnPropertyChanged();
            }
        }

        public int TurnNumber
        {
            get => myTurnNumber;
            set
            {
                if (value == myTurnNumber) return;
                myTurnNumber = value;
                OnPropertyChanged();
            }
        }

        public int MaxTurns
        {
            get => myMaxTurns;
            set
            {
                if (value == myMaxTurns) return;
                myMaxTurns = value;
                OnPropertyChanged();
            }
        }

        public string TurnText
        {
            get => myTurnText;
            set
            {
                if (value == myTurnText) return;
                myTurnText = value;
                OnPropertyChanged();
            }
        }

        public string NextRoundIn
        {
            get => myNextRoundIn;
            set
            {
                if (value.Equals(myNextRoundIn)) return;
                myNextRoundIn = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BotStateViewModel> BotStates { get; }
        public ObservableCollection<BotScoreViewModel> BotScores { get; }
        public ObservableCollection<BotScoreViewModel> RoundBotScores { get; }

        private async Task StartAsync() => await Game.StartAsync();

        public ICommand StartCommand { get; }

        public void Show() => View.Show();
    }
}