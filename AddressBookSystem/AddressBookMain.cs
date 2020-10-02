using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public static List<Contacts> listCon = new List<Contacts>();
        static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            Calling.CallingAddressBook();
        }
        
    }
}
