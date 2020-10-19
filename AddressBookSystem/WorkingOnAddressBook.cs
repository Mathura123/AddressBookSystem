using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBookSystem
{
    public class WorkingOnAddressBook
    {
        [Required(ErrorMessage ="{0} is Required")]
        public string AddressBookName { get; set; }
        public static void AddressBook()
        {
            Console.WriteLine("Enter the Address Book Name or Enter Name of the saved Address Book");
            WorkingOnAddressBook addressBookObj = new WorkingOnAddressBook();
            addressBookObj.AddressBookName = Console.ReadLine();
            AddressBookDetailsValidation.ValidateAddressBookName(addressBookObj);
            Label1:
            Console.WriteLine("\nEnter 1 to Add Contact\nEnter 2 to Edit Contact\nEnter 3 to Delete Person From Contact\nEnter 4 to Create new Address Book or to Work on saved Address Book\nEnter 5 to Search Person by City or State\nEnter 6 to show all contacts\nEnter 7 to Exit");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AddContacts(addressBookObj.AddressBookName);
                    goto Label1;
                case 2:
                    try
                    {
                        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].EditContact(addressBookObj.AddressBookName);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        goto Label1;
                    }
                    goto Label1;
                case 3:
                    try
                    {
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].DeleteContact(addressBookObj.AddressBookName);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        goto Label1;
                    }
                    goto Label1;
                case 4:
                    AddressBook();
                    break;
                case 5:
                        Contacts.SearchPersonByCityOrState();
                    goto Label1;
                case 6:
                    try
                    {
                        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AllContacts(addressBookObj.AddressBookName);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        goto Label1;
                    }
                    goto Label1;
                case 7:
                    break;
                default:
                    Console.WriteLine("Try Again. Wrong key");
                    goto Label1;
            }
        }
    }
}
