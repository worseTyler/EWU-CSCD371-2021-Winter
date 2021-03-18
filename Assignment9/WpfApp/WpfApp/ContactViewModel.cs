using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class ContactViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TwitterName { get; set; }
        private string _LastModifiedTime = DateTime.Now.ToString();

        //public event PropertyChangedEventHandler PropertyChanged;


        public string LastModifiedTime
        {
            get => _LastModifiedTime;
            set
            {
                _LastModifiedTime = DateTime.Now.ToString();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_LastModifiedTime)));
            }
        }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
