using System;
using System.Windows.Input;

namespace dvsku.Wpf.Commands {
    public class BasicCommand : ICommand {
        private readonly Action _execute;
        public event EventHandler CanExecuteChanged;

        public BasicCommand(Action execute) {
            _execute = execute;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            _execute();
        }
    }
}