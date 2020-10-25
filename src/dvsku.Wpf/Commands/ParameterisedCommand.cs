using System;
using System.Windows.Input;

namespace dvsku.Wpf.Commands {
    public class ParameterisedCommand<T> : ICommand where T : class {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
        public event EventHandler CanExecuteChanged;

        public ParameterisedCommand(Action<T> execute)
            : this(execute, null) {
        }
        public ParameterisedCommand(Action<T> execute, Predicate<T> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            if (_canExecute == null)
                return true;

            return _canExecute((T)parameter);
        }
        public void Execute(object parameter) {
            _execute((T)parameter);
        }
        public void RaiseCanExecuteChanged() {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}