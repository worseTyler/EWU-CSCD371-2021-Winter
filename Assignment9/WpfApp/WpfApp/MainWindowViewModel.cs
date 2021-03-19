using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public GenericCommand NewContactCommand { get; }

        public GenericCommand RemoveContactCommand { get; }

        public GenericCommand EditContactCommand { get; }

        private ObservableCollection<ContactViewModel> _Contacts = new();
        public ObservableCollection<ContactViewModel> Contacts
        {
            get => _Contacts;
            set => SetProperty(ref _Contacts, value);
        }


        private ContactViewModel? _SelectedContact;
        public ContactViewModel SelectedContact
        {
            get => _SelectedContact!;
            set
            {
                if (SetProperty(ref _SelectedContact, value))
                    IsEditContact = false;
            }
        }

        private bool _IsEditContact;
        public bool IsEditContact
        {
            get => _IsEditContact;
            set
            {
                if (SetProperty(ref _IsEditContact, value))
                {
                    UpdateEditText();
                    UpdateListBox();
                }

            }
        }

        private string _EditSaveText = "Edit";
        public string EditSaveText
        {
            get => _EditSaveText;
            set => SetProperty(ref _EditSaveText, value);
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
            ContactViewModel contact = new()
            {
                FirstName = "Tyler",
                LastName = "Jones",
                EmailAddress = "tylerjones@email.com",
                PhoneNumber = "509-999-1234"
            };
            SelectedContact = contact;
            Contacts.Add(contact);

            NewContactCommand = new(NewContact);
            RemoveContactCommand = new(RemoveContact);
            EditContactCommand = new(EditContact);
        }

        private void NewContact()
        {
            ContactViewModel newContact = new() { FirstName = "New Contact" };
            Contacts.Add(newContact);
            Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
            SelectedContact = newContact;
            IsEditContact = false;
        }

        private void RemoveContact()
        {
            Contacts.Remove(SelectedContact);
            Contacts = new ObservableCollection<ContactViewModel>(Contacts.OrderBy(item => item.FirstName));
        }

        private void EditContact()
        {
            IsEditContact = !IsEditContact;
            if (!IsEditContact)
            {
                int contactIndex = Contacts.IndexOf(SelectedContact);
                SelectedContact = new ContactViewModel()
                {
                    FirstName = SelectedContact.FirstName,
                    LastName = SelectedContact.LastName,
                    EmailAddress = SelectedContact.EmailAddress,
                    PhoneNumber = SelectedContact.PhoneNumber,
                    TwitterName = SelectedContact.TwitterName,
                    LastModifiedTime = DateTime.Now.ToString(), // Making a new instance of this object was the only way I could get this to work, gross
                };
                Contacts[contactIndex] = SelectedContact;
            }
        }

        private void UpdateEditText() => EditSaveText = (EditSaveText == "Edit" ? "Save" : "Edit");
    }
}
