using CodingArena.Game.Entities;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingArena.Game.Wpf
{
    [Export(typeof(IMainViewModel))]
    internal class MainViewModel : Observable, IMainViewModel
    {
        private IMainView View { get; }
        private string myText;

        [ImportingConstructor]
        public MainViewModel(IMainView view)
        {
            View = view;
            View.DataContext = this;
            StartCommand = new DelegateCommand(async () => await StartAsync());
        }

        public IGame Game { get; set; }

        private async Task StartAsync() => await Game.StartAsync();

        public string Text
        {
            get => myText;
            set
            {
                if (value == myText) return;
                myText = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand { get; }

        public void Show() => View.Show();
    }
}