using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public GenericCommand NewContactCommand { get; }

        public GenericCommand RemoveContactCommand { get; }

        private ObservableCollection<ContactViewModel> _Contacts = new();
        public ObservableCollection<ContactViewModel> Contacts
        {
            get => _Contacts;
            set => SetProperty(ref _Contacts, value);
        }


        private ContactViewModel _SelectedContact;
        public ContactViewModel SelectedContact
        {
            get => _SelectedContact;
            set
            {
                if(SetProperty(ref _SelectedContact, value))
                    UpdateListBox();   
            }


        }

        private void UpdateListBox()
        {
            Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
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
            ContactViewModel contactViewModel = new()
            {
                FirstName = "Tyler",
                LastName = "Jones"
            };

            ContactViewModel contactViewModel2 = new()
            {
                FirstName = "Cccc",
                LastName = "Jones"
            };
            Contacts.Add(contactViewModel);
            Contacts.Add(contactViewModel2);
            Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
            NewContactCommand = new(NewContact);
            RemoveContactCommand = new(RemoveContact);
        }

        private async void NewContact()
        {
            try
            {
                await NewContactAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task NewContactAsync()
        {
            await Task.Run(() =>
            {
                ContactViewModel newContact = new() { FirstName = "New Contact" };
                App.Current.Dispatcher.Invoke(() =>
                {
                    Contacts.Add(newContact);
                    Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
                });
                SelectedContact = newContact;
            });
        }

        private void RemoveContact()
        {
            Contacts.Remove(SelectedContact);
            Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
        }
    }

    public class GenericCommand : ICommand
    {
        public Action Action { get; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => Action.Invoke();

        public GenericCommand(Action action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }
    }
}
