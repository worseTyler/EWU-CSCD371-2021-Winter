using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }

        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                if (SetProperty(ref _UserName, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _Password = "S3cr3t";
        public string Password
        {
            get => _Password;
            set
            {
                if (SetProperty(ref _Password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private bool _IsLoggedIn;
        public bool IsLoggedIn
        {
            get => _IsLoggedIn;
            set => SetProperty(ref _IsLoggedIn, value);
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(DoLogin, CanLogin);
        }
        //We do login here... trust me
        public void DoLogin()
        {
            if (string.Equals(UserName, "Kevin", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Password, "S3cr3t", StringComparison.Ordinal))
            {
                IsLoggedIn = true;
            }
            IsLoggedIn = false;
        }

        public bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) &&
                   !string.IsNullOrWhiteSpace(Password);
        }
    }

    public class RelayCommand : ICommand
    {
        private Action ExecuteDelegate { get; }
        private Func<bool> CanExecuteDelegate { get; }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => CanExecuteDelegate.Invoke();
        public void Execute(object parameter) => ExecuteDelegate.Invoke();
        public RelayCommand(Action executeDelegate, Func<bool> canExecuteDelegate)
        {
            ExecuteDelegate = executeDelegate ?? throw new ArgumentNullException(nameof(executeDelegate));
            CanExecuteDelegate = canExecuteDelegate ?? throw new ArgumentNullException(nameof(canExecuteDelegate));
        }
    }
}
