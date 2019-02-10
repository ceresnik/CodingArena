using CodingArena.Game.Wpf.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodingArena.Game.Wpf.Common
{
    public abstract class Observable : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}