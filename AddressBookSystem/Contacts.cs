using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contacts
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
        public static void AddContacts()
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
            Contacts conObj = new Contacts(fName, sName,personAddress, personCity, personState, personZip, phoneNumber, personEmail);
            Console.WriteLine("Contact has been Added");
        }
    }
}