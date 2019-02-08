using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    internal interface IMainViewModel : IViewModel
    {
        void Show();
        string Text { get; set; }
        IGame Game { get; set; }
    }
}