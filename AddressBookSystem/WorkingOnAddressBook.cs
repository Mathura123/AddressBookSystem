using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class WorkingOnAddressBook
    {
        internal static void AddressBook(string addressBookName)
        {
            Console.WriteLine("Enter 1 to Add Contact\nEnter 2 to Edit Contact\nEnter 3 to Delete Person From Contact\nEnter 4 to Create new Address Book or to Work on saved Address Book\nEnter 5 to Exit");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    AddressBookMain.addressBookDict[addressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookName].AddContacts(addressBookName);
                    AddressBook(addressBookName);
                    break;
                case 2:
                    AddressBookMain.addressBookDict[addressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookName].EditContact(addressBookName);
                    AddressBook(addressBookName);
                    break;
                case 3:
                    AddressBookMain.addressBookDict[addressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookName].DeleteContact(addressBookName);
                    AddressBook(addressBookName);
                    break;
                case 4:
                    AddressBookMain.Main();
                    break;
                case 5:
                    AddressBookMain.addressBookDict[addressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookName].AllContacts(addressBookName);
                    AddressBook(addressBookName);
                    break;
                default:
                    Console.WriteLine("Try Again. Wrong key");
                    AddressBookMain.Main();
                    break;
            }
        }
    }
}
