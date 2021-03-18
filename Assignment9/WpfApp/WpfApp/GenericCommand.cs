using System;
using System.Windows.Input;

namespace WpfApp
{
    public class GenericCommand : ICommand
    {
        public Action Action { get; }
#pragma warning disable CS0067 // Never will actual use this in current implementation
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067


        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => Action.Invoke();

        public GenericCommand(Action action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }
    }
}
