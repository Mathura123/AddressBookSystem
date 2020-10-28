using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    public class WorkingOnAddressBook
    {
        [Required(ErrorMessage = "{0} is Required")]
        public string AddressBookName { get; set; }
        public static void AddressBook()
        {
            Console.WriteLine("=========================================");
            Console.Write("Enter the new/saved Address Book Name : ");
            WorkingOnAddressBook addressBookObj = new WorkingOnAddressBook();
            addressBookObj.AddressBookName = Console.ReadLine();
            //Validates AddressBookName. Calls Address Book method if AddressBookName is null
            AddressBookDetailsValidation.ValidateAddressBookName(addressBookObj);
            WorkAddressBook(addressBookObj);
        }
        private static void WorkAddressBook(WorkingOnAddressBook addressBookObj)
        {
            AskAddressBookOption();
            Console.Write("Your Entry : ");
            int key = Convert.ToInt32(Console.ReadLine());
            //For Storing Saved Data in CSV File to Contact List
            ActionWithGivenKey(key, addressBookObj);
        }
        private static void AskAddressBookOption()
        {
            Console.WriteLine("-----------------------------------------\n" +
                "Enter 1 : Add Contact\nEnter 2 : Edit Contact\nEnter 3 : Delete Person From Contact\n" +
                "Enter 4 : Create new Address Book or to Work on saved Address Book\n" +
                "Enter 5 : Search Person by City or State\n" +
                "Enter 6 : Sort all contacts by Name\n" +
                "Enter 7 : Sort all contacts by City\n" +
                "Enter 8 : Sort all contacts by State\n" +
                "Enter 9 : Sort all contacts by Zip\n" +
                "Enter 10 : View all Contacts in this Address Book\n" +
                "Enter 11 : View all Contacts\n"+
                "Enter 12 : Save Address Book\n" +
                "Enter 13 : Exit");
        }
        private static void ActionWithGivenKey(int key, WorkingOnAddressBook addressBookObj)
        {
            switch (key)
            {
                //For Adding new Contact
                case 1:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AddContacts(addressBookObj.AddressBookName);
                    WorkAddressBook(addressBookObj);
                    break;
                //For Editing the Contacts
                case 2:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].EditContact(addressBookObj.AddressBookName);
                    WorkAddressBook(addressBookObj);
                    break;
                //For Deleting Contacts
                case 3:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].DeleteContact(addressBookObj.AddressBookName);
                    WorkAddressBook(addressBookObj);
                    break;
                //For opening new/saved address book
                case 4:
                    AddressBook();
                    break;
                //Search By city/state
                case 5:
                    Contacts.SearchPersonByCityOrState();
                    WorkAddressBook(addressBookObj);
                    break;
                //Sort by Name
                case 6:
                    Contacts.SortByName();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by Name Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                //Sort by City
                case 7:
                    Contacts.SortByCity();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by City Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                //Sort by State
                case 8:
                    Contacts.SortByState();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by State Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                //Sort by Zip
                case 9:
                    Contacts.SortByZip();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by Zip Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                //View All Contacts
                case 10:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AllContacts(addressBookObj.AddressBookName);
                    WorkAddressBook(addressBookObj);
                    break;
                //Read JSON File
                case 11:
                    AddressBookFileIO.ReadAddressBookJSON();
                    WorkAddressBook(addressBookObj);
                    break;
                //Write to JSON File
                case 12:
                    AddressBookFileIO.WriteAddressBookJSON();
                    WorkAddressBook(addressBookObj);
                    break;
                //Exit
                case 13:
                    break;
                default:
                    Console.WriteLine("Try Again. Wrong key");
                    WorkAddressBook(addressBookObj);
                    break;
            }
        }
    }
}
