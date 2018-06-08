using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreenLeaf4._1.Helpers
{
    public class Observable : INotifyPropertyChanged
    {

        /* We need the INotifyChanged Property classes to update the model when we input
         * some values into the view. In this way we can just inherit the INotifyPropertyChanged class
         * in the classes that we want and use it on the Set method.
         */
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
