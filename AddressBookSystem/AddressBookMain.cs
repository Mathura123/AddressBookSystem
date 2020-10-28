using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public static Dictionary<string, Contacts> addressBookDict = new Dictionary<string, Contacts>();

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Address Book Program");
            Console.ResetColor();
            //Calling AddressBook Method for Choosing Option
            AddressBookFileIO.StoreAddressBookDetailsInContactsList();
            WorkingOnAddressBook.AddressBook();
        }
    }
}
