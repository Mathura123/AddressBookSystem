using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AddressBookSystem
{
    public class Contacts
    {
        private static List<Contacts> listContacts = new List<Contacts>();
        private static SortingType sortType;
        public string AddressBookName { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be of atleast of 3 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be of atleast of 3 characters")]
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
        public Contacts(string addressBookName, string firstName, string secondName, string address, string city, string state, string zip, string phoneNo, string email)
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
        label2:
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Address Book Name : {addressBookName}");
            Console.ResetColor();
            Console.Write("First Name : ");
            string fName = Console.ReadLine();
            Console.Write("Second Name : ");
            string sName = Console.ReadLine();
            if (SearchDublicates(fName, sName, addressBookName))
            {
                Console.WriteLine("\nThis Person is already in " + addressBookName + " Address Book\nTry to add another\n--------------");
                goto label2;
            }
            Console.Write("Address : ");
            string personAddress = Console.ReadLine();
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
            Contacts objContacts = new Contacts(addressBookName, fName, sName, personAddress, personCity, personState, personZip, phoneNumber, personEmail);
            if (AddressBookDetailsValidation.ValidatePersonDetails(objContacts))
            {
                listContacts.Add(objContacts);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contact has been Added to " + addressBookName);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contact has not been Added");
                Console.ResetColor();
                AddContacts(addressBookName);
            }
        }
        public void EditContact(string addressBookName)
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Edit Contact in {addressBookName}");
            Console.ResetColor();
            Console.Write("First Name : ");
            string fName = Console.ReadLine();
            Console.Write("Second Name : ");
            string sName = Console.ReadLine();
            bool personFound = false;
            foreach (Contacts item in listContacts)
            {
                if ((((item.FirstName).ToLower() == fName.ToLower()) && ((item.LastName).ToLower() == sName.ToLower())) && item.AddressBookName == addressBookName)
                {
                    Console.Write("New Address : ");
                    item.Address = Console.ReadLine();
                    Console.Write("New City : ");
                    item.City = Console.ReadLine();
                    Console.Write("New State : ");
                    item.State = Console.ReadLine();
                    Console.Write("New Address : ");
                    item.Zip = Console.ReadLine();
                    while (true)
                    {
                        Console.Write("New Phone Number : ");
                        item.PhoneNo = Console.ReadLine();
                        if (AddressBookDetailsValidation.ValidatePersonDetails(item))
                            break;
                    }
                    while (true)
                    {
                        Console.Write("New Email : ");
                        item.Email = Console.ReadLine();
                        if (AddressBookDetailsValidation.ValidatePersonDetails(item))
                            break;
                    }
                    personFound = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Details have been updated in " + addressBookName);
                    Console.ResetColor();
                }
            }
            if (personFound == false)
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Person not found");
                Console.ResetColor();
            }
        }
        public void DeleteContact(string addressBookName)
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Delete Contact in {addressBookName}");
            Console.ResetColor();
            Console.Write("First Name : ");
            string fName = Console.ReadLine();
            Console.Write("Second Name : ");
            string sName = Console.ReadLine();
            bool personFound = false;
            Contacts personToDelete = new Contacts();
            foreach (Contacts item in listContacts)
            {
                if ((((item.FirstName).ToLower() == fName.ToLower()) && ((item.LastName).ToLower() == sName.ToLower())) && item.AddressBookName == addressBookName)
                {
                    personToDelete = item;
                    personFound = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Person has been Removed from Contacts in " + addressBookName);
                    Console.ResetColor();
                    break;
                }
            }
            listContacts.Remove(personToDelete);
            if (personFound == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Person not found");
                Console.ResetColor();
            }
        }
        public void AllContacts(string addressBookName)
        {
            SortOnConditionChooses();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("All Contacts");
            Console.ResetColor();
            foreach (Contacts item in listContacts)
            {
                if (item.AddressBookName == addressBookName)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void SearchPersonByCityOrState()
        {
            SortOnConditionChooses();
            int slNo = 0;
            Console.Write("Enter City : ");
            string city = Console.ReadLine();
            Console.Write("Enter State : ");
            string state = Console.ReadLine();
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search by City " + city + " are :");
            Console.ResetColor();
            foreach (Contacts personDetails in listContacts)
            {
                if (personDetails.City.Equals(city) && personDetails.State.Equals(state))
                {
                    Console.WriteLine(personDetails);
                    slNo++;
                }
            }
            Console.WriteLine("\nCount by City is : " + slNo);
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search by State " + state + " are :");
            Console.ResetColor();
            slNo = 0;
            foreach (Contacts personDetails in listContacts)
            {
                if (personDetails.State.Equals(state))
                {
                    Console.WriteLine(personDetails);
                    slNo++;
                }
            }
            Console.WriteLine("\nCount by State is : " + slNo);
        }
        private bool SearchDublicates(string firstName, string lastName, string addressBookName)
        {
            if (listContacts.Any(e => (e.FirstName.ToLower().Equals(firstName.ToLower()) && e.LastName.ToLower().Equals(lastName.ToLower()) && e.AddressBookName.Equals(addressBookName))))
            {
                return true;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return($"AddressBookName : {AddressBookName} ,Name : {FirstName} {LastName} ,Address : {Address} ,City {City} ," +
                $"State : {State} ,Zip : {Zip} ," +
                $"PhoneNo : {PhoneNo} ,Email : {Email}");
        }
        public static void SortByName()
        {
            
            sortType = SortingType.SORT_BY_NAME;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                if (x.FirstName.CompareTo(y.FirstName) == 0)
                    return x.LastName.CompareTo(y.LastName);
                else
                    return x.FirstName.CompareTo(y.FirstName);
            });
        }
        public static void SortByCity()
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sorted Contacts by City");
            Console.ResetColor();
            sortType = SortingType.SORT_BY_CITY;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                    return x.City.CompareTo(y.City);
            });
        }
        public static void SortByState()
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sorted Contacts by State");
            Console.ResetColor();
            sortType = SortingType.SORT_BY_STATE;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return x.State.CompareTo(y.State);
            });
        }
        public static void SortByZip()
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sorted Contacts by Zip");
            Console.ResetColor();
            sortType = SortingType.SORT_BY_ZIP;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return x.Zip.CompareTo(y.Zip);
            });
        }
        private static void SortOnConditionChooses()
        {
            if (sortType == SortingType.SORT_BY_ZIP)
                SortByZip();
            else if (sortType == SortingType.SORT_BY_CITY)
                SortByCity();
            else if (sortType == SortingType.SORT_BY_STATE)
                SortByState();
            else
                SortByName();
        }
    }
    public enum SortingType
    {
        SORT_BY_NAME,
        SORT_BY_CITY,
        SORT_BY_STATE,
        SORT_BY_ZIP
    }
}