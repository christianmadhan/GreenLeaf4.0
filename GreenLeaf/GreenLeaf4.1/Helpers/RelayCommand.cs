using System;
using System.Windows.Input;

namespace GreenLeaf4._1.Helpers
{
    public class RelayCommand : ICommand
    {

        /* Relay Command is a class that helps us with commands.
         * If we have a button click function, we normally would have to direct that method
         * to the class of the view. But with the Relay Command we can execute methods from our viewmodel
         * Into our views. An example of this could be our login in button. the button is place in the view of the
         * Login.xaml, and normally the click method looks inside the Login.xaml.cs file to find the method, but
         * because we have implementet the Relay Command we can create a seperate file for login, we have a
         * Accont Helper class that manage login. This way we keep a good structure, and the code is more readable.
         */
        private readonly Action _execute;

        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);

        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
