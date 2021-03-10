using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        private Action ExecuteDelegate { get; }
        private Func<bool> CanExecuteDelegate { get; }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object _) => CanExecuteDelegate.Invoke();
        
        public void Execute(object _) => ExecuteDelegate.Invoke();

        public RelayCommand(Action executeDelegate, Func<bool> canExecuteDelegate)
        {
            ExecuteDelegate = executeDelegate ?? throw new ArgumentNullException(nameof(executeDelegate));
            CanExecuteDelegate = canExecuteDelegate ?? throw new ArgumentNullException(nameof(canExecuteDelegate));
        }
    }
}
