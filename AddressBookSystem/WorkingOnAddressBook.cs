using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBookSystem
{
    public class WorkingOnAddressBook
    {
        [Required(ErrorMessage = "{0} is Required")]
        public string AddressBookName { get; set; }
        public static void AddressBook()
        {
            Console.Write("Enter the new/saved Address Book Name : ");
            WorkingOnAddressBook addressBookObj = new WorkingOnAddressBook();
            addressBookObj.AddressBookName = Console.ReadLine();
            AddressBookDetailsValidation.ValidateAddressBookName(addressBookObj);
            //Label1:
            //Console.WriteLine("\nEnter 1 to Add Contact\nEnter 2 to Edit Contact\nEnter 3 to Delete Person From Contact\nEnter 4 to Create new Address Book or to Work on saved Address Book\nEnter 5 to Search Person by City or State\nEnter 6 to show all contacts\nEnter 7 to Exit");
            //int key = Convert.ToInt32(Console.ReadLine());
            //switch (key)
            //{
            //    case 1:
            //        AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
            //        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AddContacts(addressBookObj.AddressBookName);
            //        goto Label1;
            //    case 2:
            //        try
            //        {
            //            AddressBookMain.addressBookDict[addressBookObj.AddressBookName].EditContact(addressBookObj.AddressBookName);
            //        }
            //        catch
            //        {
            //            Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
            //            goto Label1;
            //        }
            //        goto Label1;
            //    case 3:
            //        try
            //        {
            //        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].DeleteContact(addressBookObj.AddressBookName);
            //        }
            //        catch
            //        {
            //            Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
            //            goto Label1;
            //        }
            //        goto Label1;
            //    case 4:
            //        AddressBook();
            //        break;
            //    case 5:
            //            Contacts.SearchPersonByCityOrState();
            //        goto Label1;
            //    case 6:
            //        try
            //        {
            //            AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AllContacts(addressBookObj.AddressBookName);
            //        }
            //        catch
            //        {
            //            Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
            //            goto Label1;
            //        }
            //        goto Label1;
            //    case 7:
            //        break;
            //    default:
            //        Console.WriteLine("Try Again. Wrong key");
            //        goto Label1;
            //}
            WorkAddressBook(addressBookObj);
        }
        public static void WorkAddressBook(WorkingOnAddressBook addressBookObj)
        {
            Console.WriteLine("-----------------------------------------\n" +
                "Enter 1 : Add Contact\nEnter 2 : Edit Contact\nEnter 3 : Delete Person From Contact\n" +
                "Enter 4 : Create new Address Book or to Work on saved Address Book\n" +
                "Enter 5 : Search Person by City or State\n" +
                "Enter 6 : Sort all contacts by Name\n" +
                "Enter 7 : Sort all contacts by City\n" +
                "Enter 8 : Sort all contacts by State\n" +
                "Enter 9 : Sort all contacts by Zip\n" +
                "Enter 10 : View all Contacts\n" +
                "Enter 11 : Save Address Book\n" +
                "Enter 12 : To Display Saved Address Books\n" +
                "Enter 13 : Exit");
            Console.Write("Your Entry : ");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName] = new Contacts();
                    AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AddContacts(addressBookObj.AddressBookName);
                    WorkAddressBook(addressBookObj);
                    break;
                case 2:
                    try
                    {
                        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].EditContact(addressBookObj.AddressBookName);
                        WorkAddressBook(addressBookObj);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        WorkAddressBook(addressBookObj);
                    }
                    break;
                case 3:
                    try
                    {
                        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].DeleteContact(addressBookObj.AddressBookName);
                        WorkAddressBook(addressBookObj);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        WorkAddressBook(addressBookObj);
                    }
                    break;
                case 4:
                    AddressBook();
                    break;
                case 5:
                    Contacts.SearchPersonByCityOrState();
                    WorkAddressBook(addressBookObj);
                    break;
                case 6:
                    Contacts.SortByName();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by Name Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                case 7:
                    Contacts.SortByCity();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by City Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                case 8:
                    Contacts.SortByState();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by State Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                case 9:
                    Contacts.SortByZip();
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sort by Zip Selected");
                    Console.ResetColor();
                    WorkAddressBook(addressBookObj);
                    break;
                case 10:
                    try
                    {
                        AddressBookMain.addressBookDict[addressBookObj.AddressBookName].AllContacts(addressBookObj.AddressBookName);
                        WorkAddressBook(addressBookObj);
                    }
                    catch
                    {
                        Console.WriteLine("\nAddress Book has no Contacts yet\nFirstly Add Contacts\n");
                        WorkAddressBook(addressBookObj);
                    }
                    break;
                case 11:
                    AddressBookFileIO.WriteIntoAddressBook();
                    AddressBook();
                    break;
                case 12:
                    AddressBookFileIO.ReadAddressBook();
                    AddressBook();
                    break;
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
