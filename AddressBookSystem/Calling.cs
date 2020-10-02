using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Calling
    {
        public static void CallingAddressBook()
        {
            Console.WriteLine("Enter 1 to Add Contact\nEnter 2 to Edit Contact\nEnter 3 to Exit");
            int key = Convert.ToInt32(Console.ReadLine());
            switch(key)
            {
                case 1:
                    Contacts.AddContacts();
                    Calling.CallingAddressBook();
                    break;
                case 2:
                    Contacts.EditContact();
                    Calling.CallingAddressBook();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Try Again. Wrong key");
                    Calling.CallingAddressBook();
                    break;

            }        
        }
    }
}
