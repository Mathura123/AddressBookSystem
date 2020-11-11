namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CsvHelper;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json;

    public class AddressBookFileIO
    {
        //Read txt file
        public static void ReadAddressBook()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                CustomPrint.PrintInRed($"Saved Address Book Details in TXT file");
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                sr.Close();
            }
        }
        //Write into txt file
        public static void WriteAddressBook()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";

            using (StreamWriter sr = File.AppendText(path))
            {
                SortContacts.SortOnConditionChooses(Contacts.listContacts);
                foreach (AddressBookModel personDetails in Contacts.listContacts)
                {
                    sr.WriteLine(personDetails);
                }
                sr.Close();
                CustomPrint.PrintInRed("Address Book Txt file has been Appended", false);
            }
        }
        //Read from CSV file
        public static void ReadAddressBookCSV()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBookModel>().ToList();
                CustomPrint.PrintInRed("Read Data Successfully from address book CSV");
                foreach (AddressBookModel personDetail in records)
                {
                    Console.WriteLine(personDetail);
                }
            }
        }
        //Write in CSV file
        public static void WriteAddressBookCSV()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var writer = new StreamWriter(path, false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                SortContacts.SortOnConditionChooses(Contacts.listContacts);
                csv.WriteRecords(Contacts.listContacts);
            }
        }
        //Read from JSON File
        public static void ReadAddressBookJSON()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.json";

            IList<AddressBookModel> addressDatas = JsonConvert.DeserializeObject<IList<AddressBookModel>>(File.ReadAllText(path));
            CustomPrint.PrintInRed("Read Data Successfully");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State","Zip","PhoneNo", "Email"));
            CustomPrint.PrintDashLine();
            foreach (AddressBookModel personDetail in addressDatas)
            {
                Console.WriteLine(personDetail);
            }
            CustomPrint.PrintDashLine();
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
                SortContacts.SortOnConditionChooses(Contacts.listContacts);
                jsonSerializer.Serialize(writer, Contacts.listContacts);
                CustomPrint.PrintInRed("Saved Data Successfully");
            }
        }
        //Stores saved data in csv file to Contact List- listContacts
        public static void StoreAddressBookDetailsInContactsList()
        {
            string path = @"F:\MyPrograms\Assignments\A4-AddressBook\AddressBookSystem\AddressBookSystem\Utility\AddressBook.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBookModel>().ToList();
                foreach (AddressBookModel personDetail in records)
                {
                    Contacts.listContacts.Add(personDetail);
                }
            }
        }

    }
}

