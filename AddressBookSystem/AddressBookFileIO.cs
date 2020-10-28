using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookSystem
{
    public class AddressBookFileIO
    {
        public static void WriteIntoAddressBook()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";

            using (StreamWriter sr = File.AppendText(path))
            {
                Contacts.SortOnConditionChooses();
                foreach (Contacts personDetails in Contacts.listContacts)
                {
                    sr.WriteLine(personDetails);
                }
                sr.Close();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Address Book has been Appended");
                Console.WriteLine("-----------------------------------------");
                Console.ResetColor();
            }
        }
        public static void ReadAddressBook()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Saved Address Book Details");
                Console.ResetColor();
                string s = "";
                while((s=sr.ReadLine())!=null)
                {
                    Console.WriteLine(s);
                }
                sr.Close();
            }
        }
    }
}

