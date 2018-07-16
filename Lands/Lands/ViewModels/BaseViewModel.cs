using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lands.ViewModels
{
    //para no tener que hacer todo el proceso de get y set para cada propiedad se crea una clase
           public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
            }

            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value))
                {
                    return false;
                }
                storage = value;
                OnPropertyChanged(propertyName);

                return true;
            }
        }
    }
}
