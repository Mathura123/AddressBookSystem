namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Contacts
    {
        public static List<Contacts> listContacts = new List<Contacts>();
        public string AddressBookName { get; set; }
        //First Name is Required and should be of atleast 3 characters
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be of atleast of 3 characters")]
        public string FirstName { get; set; }
        //Second Name is Required and should be of atleast 3 characters
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{3} must be of atleast of 3 characters")]
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
                CustomPrint.PrintInRed($"Contact has been Added to {addressBookName}", false);
            }
            //Given Error if objContacts is invalid 
            else
            {
                CustomPrint.PrintInMagenta($"Contact has not been Added to", false);
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
                CustomPrint.PrintInRed("Details have been updated in " + addressBookName, false);
            }
            if (personFound == false)
                CustomPrint.PrintInMagenta("Person not found");
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
                CustomPrint.PrintInRed("Person removed from Contacts in " + addressBookName, false);
                break;
            }
            //Removes the Contacts if person found
            listContacts.Remove(personToDelete);
            //Gives error if person not found
            if (personFound == false)
                CustomPrint.PrintInMagenta("Person not found", false);
        }
        public static void AllContacts(string addressBookName)
        {
            //For Sorting Accoring to sorting type choosed
            SortContacts.SortOnConditionChooses(Contacts.listContacts);
            CustomPrint.PrintInRed("All Contacts");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email"));
            CustomPrint.PrintDashLine();
            foreach (Contacts item in listContacts)
            {
                if (item.AddressBookName == addressBookName)
                {
                    Console.WriteLine(item);
                }
            }
            CustomPrint.PrintDashLine();
        }
        public static void SearchPersonByCityOrState()
        {
            //For Sorting Accoring to sorting type choosed
            SortContacts.SortOnConditionChooses(Contacts.listContacts);
            //For counting no of people in same city/state
            int slNo = 0;
            Console.Write("Enter City : ");
            string city = Console.ReadLine();
            Console.Write("Enter State : ");
            string state = Console.ReadLine();
            CustomPrint.PrintInRed("Search by City " + city + " are :\n");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email"));
            CustomPrint.PrintDashLine();
            foreach (Contacts personDetails in listContacts.Where(x => (x.City.ToLower().Equals(city.ToLower()) && x.State.ToLower().Equals(state.ToLower()))))
            {
                Console.WriteLine(personDetails);
                slNo++;
            }
            CustomPrint.PrintDashLine();
            Console.WriteLine("\nCount by City is : " + slNo);
            CustomPrint.PrintInRed("Search by State " + state + " are :\n");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "PhoneNo", "Email"));
            CustomPrint.PrintDashLine();
            slNo = 0;
            foreach (Contacts personDetails in listContacts)
            {
                if (personDetails.State.Equals(state))
                {
                    Console.WriteLine(personDetails);
                    slNo++;
                }
            }
            CustomPrint.PrintDashLine();
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
            string name = FirstName + " " + LastName;
            return CustomPrint.PrintRow(AddressBookName, name, Address, City, State, Zip, PhoneNo, Email);
        }
        private static string[] AskDetailsForAdding(string addressBookName)
        {
        label2:
            string[] personDetail = new string[9];
            personDetail[0] = addressBookName;
            CustomPrint.PrintInRed($"Address Book Name : {addressBookName}", true);
            Console.Write("First Name : ");
            personDetail[1] = Console.ReadLine();
            Console.Write("Second Name : ");
            personDetail[2] = Console.ReadLine();
            if (SearchDublicates(personDetail[1], personDetail[2], addressBookName))
            {
                CustomPrint.PrintInMagenta("This Person is already in " + addressBookName + " Address Book\nTry to add another", true);
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
                CustomPrint.PrintInRed($"Delete Contact in {addressBookName}");
            else
                CustomPrint.PrintInMagenta($"Edit Contact in {addressBookName}");
            Console.Write("First Name : ");
            name[0] = Console.ReadLine();
            Console.Write("Second Name : ");
            name[1] = Console.ReadLine();
            return name;
        }
    }
    /// <summary>Class for sorting contacts</summary>
    public class SortContacts
    {
        public static SortingType sortType = SortingType.DEFAULT_SORTING;
        /// <summary>Enum that for saving sorting type</summary>
        public enum SortingType
        {
            SORT_BY_NAME,
            SORT_BY_CITY,
            SORT_BY_STATE,
            SORT_BY_ZIP,
            DEFAULT_SORTING
        }
        /// <summary>Sorts contact list by name.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByName(List<Contacts> listContacts)
        {
            sortType = SortingType.SORT_BY_NAME;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return (x.FirstName.ToLower() + x.LastName.ToLower()).CompareTo((y.FirstName.ToLower() + y.LastName.ToLower()));
            });
        }
        /// <summary>Sorts contact list by city.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByCity(List<Contacts> listContacts)
        {
            sortType = SortingType.SORT_BY_CITY;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return (x.City.ToLower()).CompareTo((y.City.ToLower()));
            });
        }
        /// <summary>Sorts contact list by State.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByState(List<Contacts> listContacts)
        {
            sortType = SortingType.SORT_BY_STATE;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return (x.State.ToLower()).CompareTo((y.State.ToLower()));
            });
        }
        /// <summary>Sorts contact list by zip.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByZip(List<Contacts> listContacts)
        {
            sortType = SortingType.SORT_BY_ZIP;
            listContacts.Sort(delegate (Contacts x, Contacts y)
            {
                return (x.Zip).CompareTo((y.Zip));
            });
        }
        /// <summary>Sorts contact list on condition choosen.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortOnConditionChooses(List<Contacts> listContacts)
        {
            if (sortType == SortingType.SORT_BY_ZIP)
                SortByZip(listContacts);
            if (sortType == SortingType.SORT_BY_CITY)
                SortByCity(listContacts);
            if (sortType == SortingType.SORT_BY_STATE)
                SortByState(listContacts);
            if (sortType == SortingType.SORT_BY_NAME)
                SortByName(listContacts);
        }
    }

}