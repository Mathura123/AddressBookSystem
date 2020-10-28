using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace AddressBookSystem
{
    public class AddressBookFileIO
    {
        private static object csvExport;

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
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                sr.Close();
            }
        }
        public static void WriteAddressBookCSV()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saved Data Successfully to Address Book csv");
                Console.ResetColor();
                Contacts.SortOnConditionChooses();
                csv.WriteRecords(Contacts.listContacts);
            }
        }
        public static void ReadAddressBookCSV()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Read Data Successfully from address book csv");
                Console.ResetColor();
                foreach (Contacts personDetail in records)
                {
                    Console.WriteLine(personDetail);
                }
            }
        }
        public static void StoreAddressBookDetailsInContactsList()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                Console.ResetColor();
                foreach (Contacts personDetail in records)
                {
                    Contacts.listContacts.Add(personDetail);
                }
            }
        }

    }
}

