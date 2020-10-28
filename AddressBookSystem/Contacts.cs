namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Contacts
    {
        public static List<Contacts> listContacts = new List<Contacts>();
        public static SortingType sortType = SortingType.DEFAULT_SORTING;
        public string AddressBookName { get; set; }
        //First Name is Required and should be of atleast 3 characters
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be of atleast of 3 characters")]
        public string FirstName { get; set; }
        //Second Name is Required and should be of atleast 3 characters
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be of atleast of 3 characters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        //For Validating Phone No
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        //for Validating Email
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Contacts()
        {
        }
        public Contacts(string[] personDetail)
        {
            AddressBookName = personDetail[0];
            FirstName = personDetail[1];
            LastName = personDetail[2];
            Address = personDetail[3];
            City = personDetail[4];
            State = personDetail[5];
            Zip = personDetail[6];
            PhoneNo = personDetail[7];
            Email = personDetail[8];
        }
        public static void AddContacts(string addressBookName)
        {
            //Creates new Contact object by getting personDeatils from AskDetailsForAdding
            Contacts objContacts = new Contacts(AskDetailsForAdding(addressBookName));
            //Adds objContact to listContacts if objContacts is valid 
            if (AddressBookDetailsValidation.Validate(objContacts))
            {
                listContacts.Add(objContacts);
                PrintInRed($"Contact has been Added to {addressBookName}",false);
            }
            //Given Error if objContacts is invalid 
            else
            {
                PrintInMagenta($"Contact has not been Added to",false);
                AddContacts(addressBookName);
            }
        }
        public static void EditContact(string addressBookName)
        {
            //gets First Name And Second Name from User using 
            string[] name = AskDetailForDeletingOrEditing(addressBookName, "Edit");
            string fName = name[0];
            string sName = name[1];
            bool personFound = false;
            //loops through contacts where First Name,Second Name and AddressBookName get matched
            Func<Contacts, bool> condition = item => ((item.FirstName).ToLower() == fName.ToLower() && (item.LastName).ToLower() == sName.ToLower() && item.AddressBookName == addressBookName);
            foreach (Contacts item in listContacts.Where(condition))
            {
                Console.Write("New Address : ");
                item.Address = Console.ReadLine();
                Console.Write("New City : ");
                item.City = Console.ReadLine();
                Console.Write("New State : ");
                item.State = Console.ReadLine();
                Console.Write("New Address : ");
                item.Zip = Console.ReadLine();
                //For having Valid Phone No
                while (true)
                {
                    Console.Write("New Phone Number : ");
                    item.PhoneNo = Console.ReadLine();
                    if (AddressBookDetailsValidation.Validate(item))
                        break;
                }
                //For having Valid Email
                while (true)
                {
                    Console.Write("New Email : ");
                    item.Email = Console.ReadLine();
                    if (AddressBookDetailsValidation.Validate(item))
                        break;
                }
                personFound = true;
                PrintInRed("Details have been updated in " + addressBookName, false);
            }
            if (personFound == false)
                PrintInMagenta("Person not found");
        }
        public static void DeleteContact(string addressBookName)
        {
            //gets First Name And Second Name from User using 
            string[] name = AskDetailForDeletingOrEditing(addressBookName, "Delete");
            string fName = name[0];
            string sName = name[1];
            bool personFound = false;
            Contacts personToDelete = new Contacts();
            //loops through contacts where First Name,Second Name and AddressBookName get matched
            Func<Contacts, bool> condition = item => ((item.FirstName).ToLower() == fName.ToLower() && (item.LastName).ToLower() == sName.ToLower() && item.AddressBookName == addressBookName);
            foreach (Contacts item in listContacts.Where(condition))
            {
                personToDelete = item;
                personFound = true;
                PrintInRed("Person removed from Contacts in " + addressBookName, false);
                break;
            }
            //Removes the Contacts if person found
            listContacts.Remove(personToDelete);
            //Gives error if person not found
            if (personFound == false)
                PrintInMagenta("Person not found", false);
        }
        public static void AllContacts(string addressBookName)
        {
            //For Sorting Accoring to sorting type choosed
            SortOnConditionChooses();
            PrintInRed("All Contacts");
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
            //For Sorting Accoring to sorting type choosed
            SortOnConditionChooses();
            //For counting no of people in same city/state
            int slNo = 0;
            Console.Write("Enter City : ");
            string city = Console.ReadLine();
            Console.Write("Enter State : ");
            string state = Console.ReadLine();
            PrintInRed("Search by City " + city + " are :\n");
            foreach (Contacts personDetails in listContacts.Where(x => (x.City.Equals(city) && x.State.Equals(state))))
            {
                Console.WriteLine(personDetails);
                slNo++;
            }
            Console.WriteLine("\nCount by City is : " + slNo);
            PrintInRed("Search by State " + state + " are :\n");
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
        //For Searching dublicate person
        private static bool SearchDublicates(string firstName, string lastName, string addressBookName)
        {
            if (listContacts.Any(e => (e.FirstName.ToLower().Equals(firstName.ToLower()) && e.LastName.ToLower().Equals(lastName.ToLower()) && e.AddressBookName.Equals(addressBookName))))
            {
                return true;
            }
            else
                return false;
        }
        //Overrides ToString Method for object of Contacts Class
        public override string ToString()
        {
            return ($"AddressBookName : {AddressBookName} ,Name : {FirstName} {LastName} ,Address : {Address} ,City {City} ," +
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
            sortType = SortingType.SORT_BY_CITY;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return x.City.CompareTo(y.City);
            });
        }
        public static void SortByState()
        {
            sortType = SortingType.SORT_BY_STATE;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return x.State.CompareTo(y.State);
            });
        }
        public static void SortByZip()
        {
            sortType = SortingType.SORT_BY_ZIP;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return x.Zip.CompareTo(y.Zip);
            });
        }
        public static void SortOnConditionChooses()
        {
            if (sortType == SortingType.SORT_BY_ZIP)
                SortByZip();
            if (sortType == SortingType.SORT_BY_CITY)
                SortByCity();
            if (sortType == SortingType.SORT_BY_STATE)
                SortByState();
            if(sortType == SortingType.SORT_BY_NAME)
                SortByName();
        }
        private static string[] AskDetailsForAdding(string addressBookName)
        {
        label2:
            string[] personDetail = new string[9];
            personDetail[0] = addressBookName;
            PrintInRed($"Address Book Name : {addressBookName}", true);
            Console.Write("First Name : ");
            personDetail[1] = Console.ReadLine();
            Console.Write("Second Name : ");
            personDetail[2] = Console.ReadLine();
            if (SearchDublicates(personDetail[1], personDetail[2], addressBookName))
            {
                PrintInMagenta("This Person is already in " + addressBookName + " Address Book\nTry to add another", true);
                goto label2;
            }
            Console.Write("Address : ");
            personDetail[3] = Console.ReadLine();
            Console.Write("City : ");
            personDetail[4] = Console.ReadLine();
            Console.Write("State : ");
            personDetail[5] = Console.ReadLine();
            Console.Write("Zip : ");
            personDetail[6] = Console.ReadLine();
            Console.Write("Phone Number : ");
            personDetail[7] = Console.ReadLine();
            Console.Write("Email Id : ");
            personDetail[8] = Console.ReadLine();
            return personDetail;
        }
        private static string[] AskDetailForDeletingOrEditing(string addressBookName, string func)
        {
            string[] name = new string[2];
            if (func == "Delete")
                PrintInRed($"Delete Contact in {addressBookName}");
            else
                PrintInMagenta($"Edit Contact in {addressBookName}");
            Console.Write("First Name : ");
            name[0] = Console.ReadLine();
            Console.Write("Second Name : ");
            name[1] = Console.ReadLine();
            return name;
        }
        //For printing headers and results in red
        public static void PrintInRed(string s, bool header = true, bool footer = false)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
        //For printing Errors in Magenta
        public static void PrintInMagenta(string s, bool header = true, bool footer = false)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
    }
    //Enum that for saving sorting type
    public enum SortingType
    {
        SORT_BY_NAME,
        SORT_BY_CITY,
        SORT_BY_STATE,
        SORT_BY_ZIP,
        DEFAULT_SORTING
    }
}