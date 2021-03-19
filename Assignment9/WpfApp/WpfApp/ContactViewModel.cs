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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? TwitterName { get; set; }

        private string _LastModifiedTime = DateTime.Now.ToString();
        public string LastModifiedTime
        {
            get => _LastModifiedTime;
            set => _LastModifiedTime = DateTime.Now.ToString();
            //{
            //    CustomFunc?.Invoke();
            //}
        }

        //Func<string>? CustomFunc;
        //public ContactViewModel(Func<string>? CustomLastModifiedTime = null)
        //{
        //    if (CustomLastModifiedTime is not null)
        //        CustomFunc = CustomLastModifiedTime;
        //    else
        //        CustomFunc = () => DateTime.Now.ToString();
        //}

        // This would probably work as a seam to my code, I could provide custom
        // implementation in my tests that would look something like
        // () => ++Counter.ToString()
        // to make sure that the string is being updated
    }
}
