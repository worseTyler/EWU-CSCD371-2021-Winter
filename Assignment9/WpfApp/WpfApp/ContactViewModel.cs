using System;
using System.Collections.Generic;
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
        public string LastModifiedTime { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
