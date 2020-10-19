using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    class Contacts
    {
        private static List<Contacts> listContacts = new List<Contacts>();
        public string AddressBookName { get; set; }

        [Required(ErrorMessage ="{0} is Required")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="{0} must be of atleast of 3 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="{0} is Required")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="{0} must be of atleast of 3 characters")]
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Contacts()
        {
        }
        public Contacts(string addressBookName,string firstName, string secondName, string address, string city, string state, string zip, string phoneNo, string email)
        {
            AddressBookName = addressBookName;
            FirstName = firstName;
            LastName = secondName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNo = phoneNo;
            Email = email;
        }
        public void AddContacts(string addressBookName)
        {
            Console.Write("First Name : ");
            string fName = Console.ReadLine();
            Console.Write("Second Name : ");
            string sName = Console.ReadLine();
            Console.Write("Address : ");
            string personAddress= Console.ReadLine();
            Console.Write("City : ");
            string personCity = Console.ReadLine();
            Console.Write("State : ");
            string personState = Console.ReadLine();
            Console.Write("Zip : ");
            string personZip = Console.ReadLine();
            Console.Write("Phone Number : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Email Id : ");
            string personEmail = Console.ReadLine();
            if(AddressBookDetailsValidation.ValidatePersonDetails(fName, sName, phoneNumber, personEmail))
            {
                Contacts objContacts = new Contacts(addressBookName, fName, sName, personAddress, personCity, personState, personZip, phoneNumber, personEmail);
                listContacts.Add(objContacts);
                Console.WriteLine("Contact has been Added to " + addressBookName);
            }
            else
            {
                AddContacts(addressBookName);
            }
        }
        public void EditContact(string addressBookName)
        {
            Console.WriteLine("Enter First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string sName = Console.ReadLine();
            bool personFound = false;
            foreach(Contacts item in listContacts)
            {
                if((((item.FirstName).ToLower() == fName.ToLower()) && ((item.LastName).ToLower() == sName.ToLower())) && item.AddressBookName == addressBookName)
                {
                    Console.WriteLine("Enter new Address");
                    item.Address = Console.ReadLine();
                    Console.WriteLine("Enter new City");
                    item.City = Console.ReadLine();
                    Console.WriteLine("Enter new State");
                    item.State = Console.ReadLine();
                    Console.WriteLine("Enter new Address");
                    item.Zip = Console.ReadLine();
                    Console.WriteLine("Enter new Phone Number");
                    item.PhoneNo = Console.ReadLine();
                    Console.WriteLine("Enter new Email");
                    item.Email = Console.ReadLine();
                    personFound = true;
                    Console.WriteLine("Details have been updated in "+ addressBookName);
                }
            }
            if(personFound==false)
            {
                Console.WriteLine("Person not found");
            }
        }
        public void DeleteContact(string addressBookName)
        {
            Console.WriteLine("Enter First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Second Name");
            string sName = Console.ReadLine();
            bool personFound = false;
            Contacts personToDelete = new Contacts();
            foreach (Contacts item in listContacts)
            {
                if ((((item.FirstName).ToLower() == fName.ToLower()) && ((item.LastName).ToLower() == sName.ToLower())) && item.AddressBookName == addressBookName)
                {
                    personToDelete= item;
                    personFound = true;
                    Console.WriteLine("Person has been Removed from Contacts in " + addressBookName);
                    break;
                }
            }
            listContacts.Remove(personToDelete);
            if (personFound == false)
            {
                Console.WriteLine("Person not found");
            }
        }
        public void AllContacts(string addressBookName)
        {
            foreach (Contacts item in listContacts)
            {
                if (item.AddressBookName == addressBookName)
                {
                    Console.WriteLine("\nName : " + item.FirstName +" " + item.LastName + "\nAddress : " +item.Address + "\nCity : " + item.City+"\nState : " + item.State+"\nZip : " + item.Zip+"\n");
                }
            }
        }
    }
}