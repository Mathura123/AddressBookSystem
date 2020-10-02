using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contacts
    {
        internal string addressBookName;
        internal string firstName;
        internal string secondName;
        internal string address;
        internal string city;
        internal string state;
        internal int zip;
        internal int phoneNo;
        internal string email;
        internal static List<Contacts> listContacts = new List<Contacts>();
        internal Contacts()
        {
        }
        internal Contacts(string addressBookName,string firstName, string secondName, string address, string city, string state, int zip, int phoneNo, string email)
        {
            this.addressBookName = addressBookName;
            this.firstName = firstName;
            this.secondName = secondName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }
        internal void AddContacts(string addressBookName)
        {
            Console.WriteLine("Enter First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string sName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string personAddress= Console.ReadLine();
            Console.WriteLine("Enter City");
            string personCity = Console.ReadLine();
            Console.WriteLine("Enter State");
            string personState = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            int personZip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email Id");
            string personEmail = Console.ReadLine();
            Contacts objContacts = new Contacts(addressBookName,fName, sName, personAddress, personCity, personState, personZip, phoneNumber, personEmail);
            listContacts.Add(objContacts);
            Console.WriteLine("Contact has been Added to " + addressBookName);
        }
        internal void EditContact(string addressBookName)
        {
            Console.WriteLine("Enter First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string sName = Console.ReadLine();
            bool personFound = false;
            foreach(Contacts item in listContacts)
            {
                if((((item.firstName).ToLower() == fName.ToLower()) && ((item.secondName).ToLower() == sName.ToLower())) && item.addressBookName == addressBookName)
                {
                    Console.WriteLine("Enter new Address");
                    item.address = Console.ReadLine();
                    Console.WriteLine("Enter new City");
                    item.city = Console.ReadLine();
                    Console.WriteLine("Enter new State");
                    item.state = Console.ReadLine();
                    Console.WriteLine("Enter new Address");
                    item.zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new Phone Number");
                    item.phoneNo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new Email");
                    item.email = Console.ReadLine();
                    personFound = true;
                    Console.WriteLine("Details have been updated in "+ addressBookName);
                }
            }
            if(personFound==false)
            {
                Console.WriteLine("Person not found");
            }
        }
        internal void DeleteContact(string addressBookName)
        {
            Console.WriteLine("Enter First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string sName = Console.ReadLine();
            bool personFound = false;
            Contacts personToDelete = new Contacts();
            foreach (Contacts item in listContacts)
            {
                if ((((item.firstName).ToLower() == fName.ToLower()) && ((item.secondName).ToLower() == sName.ToLower())) && item.addressBookName == addressBookName)
                {
                    personToDelete= item;
                    personFound = true;
                    Console.WriteLine("Person has been Removed from Contacts in " + addressBookName);
                }
            }
            listContacts.Remove(personToDelete);
            if (personFound == false)
            {
                Console.WriteLine("Person not found");
            }
        }
        internal void AllContacts(string addressBookName)
        {
            foreach (Contacts item in listContacts)
            {
                if (item.addressBookName == addressBookName)
                {
                    Console.WriteLine(item.firstName + " " + item.secondName);
                }
            }
        }
    }
}