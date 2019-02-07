using System.ComponentModel;
using System.Runtime.CompilerServices;
using CodingArena.Game.Wpf.Annotations;

namespace CodingArena.Game.Wpf
{
    public abstract class Observable : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}