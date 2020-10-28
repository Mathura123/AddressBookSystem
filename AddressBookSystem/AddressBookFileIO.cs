using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;


namespace AddressBookSystem
{
    public class AddressBookFileIO
    {
        //Write into txt file
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
        //Read txt file
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
        //Write in CSV file
        public static void WriteAddressBookCSV()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var writer = new StreamWriter(path,false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                Contacts.SortOnConditionChooses();
                csv.WriteRecords(Contacts.listContacts);
            }
        }
        //Read from CSV file
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
        //Stores saved data in csv file to Contact List- listContacts
        public static void StoreAddressBookDetailsInContactsList()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                foreach (Contacts personDetail in records)
                {
                    Contacts.listContacts.Add(personDetail);
                }
            }
        }
        //Read from JSON File
        public static void ReadAddressBookJSON()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.json";

            IList<Contacts> addressDatas = JsonConvert.DeserializeObject<IList<Contacts>>(File.ReadAllText(path));
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Read Data Successfully from address book JOSN");
            Console.ResetColor();
            foreach (Contacts personDetail in addressDatas)
            {
                Console.WriteLine(personDetail);
            }
            WriteAddressBookCSV();
        }
        //Write in JSON File
        public static void WriteAddressBookJSON()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.json";
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saved Data Successfully to Address Book JSON");
                Console.ResetColor();
                Contacts.SortOnConditionChooses();
                jsonSerializer.Serialize(writer, Contacts.listContacts);
            }
        }
    }
}

