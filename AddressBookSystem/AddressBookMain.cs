using System;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("Enter 1 to Create Contact");
            int enterKey = Convert.ToInt32(Console.ReadLine());
            switch (enterKey)
            {
                case 1:
                    AddressBookMain.CreateContacts();
                    break;
                default:
                    Console.WriteLine("Wrong Key. Try once more\n");
                    AddressBookMain.Main();
                    break;
            }
        }
        static void CreateContacts()
        {
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string secondName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            int phoneNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email Id");
            string email = Console.ReadLine();
            Contacts conObj = new Contacts(firstName,secondName,address,city,state,zip,phoneNo,email);
            Console.WriteLine("Contact has been Created");
        }
    }
    public class Contacts
    {
        public string firstName;
        public string secondName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public int phoneNo;
        public string email;
        public Contacts(string firstName, string secondName, string address, string city, string state, int zip, int phoneNo, string email)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }
    }
}
