namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Contacts
    {
        /// <summary>The list that stores address book details</summary>
        public static List<AddressBookModel> listContacts = new List<AddressBookModel>();

        /// <summary>Adds the contacts.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        public static void AddContacts(string addressBookName)
        {
            //Creates new Contact object by getting personDeatils from AskDetailsForAdding
            AddressBookModel objContacts = new AddressBookModel(AskDetailsForAdding(addressBookName));
            //Adds objContact to listContacts if objContacts is valid 
            if (AddressBookDetailsValidation.Validate(objContacts))
            {
                objContacts.DateAdded = DateTime.Now;
                if (AddressBookDBWork.AddContactToDB(objContacts))
                {
                    listContacts.Add(objContacts);
                    CustomPrint.PrintInRed($"Contact has been Added to {addressBookName}", false);
                }
                else
                {
                    CustomPrint.PrintInMagenta($"Contact has not been Added to", false);
                }
            }
            //Given Error if objContacts is invalid 
            else
            {
                CustomPrint.PrintInMagenta($"Contact has not been Added to", false);
                AddContacts(addressBookName);
            }
        }
        /// <summary>Edits the contact.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        public static void EditContact(string addressBookName)
        {
            //gets First Name And Second Name from User using 
            string[] name = AskDetailForDeletingOrEditing(addressBookName, "Edit");
            string fName = name[0];
            string sName = name[1];
            bool personFound = false;
            //loops through contacts where First Name,Second Name and AddressBookName get matched
            Func<AddressBookModel, bool> condition = item => ((item.FirstName).ToLower() == fName.ToLower() && (item.LastName).ToLower() == sName.ToLower() && item.AddressBookName == addressBookName);
            foreach (AddressBookModel item in listContacts.Where(condition))
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
                AddressBookDBWork.UpdateContactInDB(item);
                CustomPrint.PrintInRed("Details have been updated in " + addressBookName, false);
            }
            if (personFound == false)
                CustomPrint.PrintInMagenta("Person not found");
        }
        /// <summary>Deletes the contact.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        public static void DeleteContact(string addressBookName)
        {
            //gets First Name And Second Name from User using 
            string[] name = AskDetailForDeletingOrEditing(addressBookName, "Delete");
            string fName = name[0];
            string sName = name[1];
            bool personFound = false;
            AddressBookModel personToDelete = new AddressBookModel();
            //loops through contacts where First Name,Second Name and AddressBookName get matched
            Func<AddressBookModel, bool> condition = item => ((item.FirstName).ToLower() == fName.ToLower() && (item.LastName).ToLower() == sName.ToLower() && item.AddressBookName == addressBookName);
            foreach (AddressBookModel item in listContacts.Where(condition))
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
        /// <summary>View all contacts in same given address book.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        public static void AllContactsInSameAddressBook(string addressBookName)
        {
            //For Sorting Accoring to sorting type choosed
            SortContacts.SortOnConditionChooses(Contacts.listContacts);
            CustomPrint.PrintInRed($"All Contacts in address book {addressBookName}");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
            CustomPrint.PrintDashLine();
            foreach (AddressBookModel item in listContacts)
            {
                if (item.AddressBookName == addressBookName)
                {
                    Console.WriteLine(item);
                }
            }
            CustomPrint.PrintDashLine();
        }
        /// <summary>View all contacts in DB.</summary>
        public static void AllContacts()
        {
            //For Sorting Accoring to sorting type choosed
            SortContacts.SortOnConditionChooses(Contacts.listContacts);
            CustomPrint.PrintInRed($"All Contacts in every address book");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
            CustomPrint.PrintDashLine();
            foreach (AddressBookModel item in listContacts)
            {
                Console.WriteLine(item);
            }
            CustomPrint.PrintDashLine();

        }
        /// <summary>Views All contacts in same state or city for all address book.</summary>
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
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
            CustomPrint.PrintDashLine();
            foreach (AddressBookModel personDetails in listContacts.Where(x => (x.City.ToLower().Equals(city.ToLower()) && x.State.ToLower().Equals(state.ToLower()))))
            {
                Console.WriteLine(personDetails);
                slNo++;
            }
            CustomPrint.PrintDashLine();
            Console.WriteLine("\nCount by City is : " + slNo);
            CustomPrint.PrintInRed("Search by State " + state + " are :\n");
            CustomPrint.PrintDashLine();
            Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
            CustomPrint.PrintDashLine();
            slNo = 0;
            foreach (AddressBookModel personDetails in listContacts)
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
        /// <summary>Retirves alls the contacts in given date range.</summary>
        public static void AllContactsInGivenDateRange()
        {
            try
            {
                DateTime[] dates = AskForDateRange();
                AddressBookDBWork.GetContactInGivenDateRange(dates[0], dates[1]);
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message + "\nTry Again");
                AllContactsInGivenDateRange();
            }
        }

        /// <summary>Searches the dublicates.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="addressBookName">Name of the address book.</param>
        /// <returns>if dublicate search successfull then returns true else false</returns>
        private static bool SearchDublicates(string firstName, string lastName, string addressBookName)
        {
            if (listContacts.Any(e => (e.FirstName.ToLower().Equals(firstName.ToLower()) && e.LastName.ToLower().Equals(lastName.ToLower()) && e.AddressBookName.Equals(addressBookName))))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>Asks the details for adding.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
        /// <summary>Asks the detail for deleting or editing.</summary>
        /// <param name="addressBookName">Name of the address book.</param>
        /// <param name="func">The function.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
        /// <summary>Asks for date range.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="AddressBookException">Entered Date is invalid
        /// or
        /// Entered Date is invalid
        /// or
        /// Start Date can not be after End Date</exception>
        private static DateTime[] AskForDateRange()
        {
            DateTime[] dates = new DateTime[2];
            Console.Write("Enter the Start Date in DD/MM/YYYY format : ");
            try
            {
                dates[0] = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new AddressBookException(AddressBookException.ExceptionType.INVALID_DATE, "Entered Date is invalid");
            }
            Console.Write("Enter the End Date in DD/MM/YYYY format : ");
            try
            {
                dates[1] = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new AddressBookException(AddressBookException.ExceptionType.INVALID_DATE, "Entered Date is invalid");
            }
            if (dates[0] > dates[1])
                throw new AddressBookException(AddressBookException.ExceptionType.INVALID_DATE, "Start Date can not be after End Date");
            return dates;
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
        public static void SortByName(List<AddressBookModel> listContacts)
        {
            sortType = SortingType.SORT_BY_NAME;
            listContacts.Sort(delegate (AddressBookModel x, AddressBookModel y)
            {
                return (x.FirstName.ToLower() + x.LastName.ToLower()).CompareTo((y.FirstName.ToLower() + y.LastName.ToLower()));
            });
        }
        /// <summary>Sorts contact list by city.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByCity(List<AddressBookModel> listContacts)
        {
            sortType = SortingType.SORT_BY_CITY;
            listContacts.Sort(delegate (AddressBookModel x, AddressBookModel y)
            {
                return (x.City.ToLower()).CompareTo((y.City.ToLower()));
            });
        }
        /// <summary>Sorts contact list by State.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByState(List<AddressBookModel> listContacts)
        {
            sortType = SortingType.SORT_BY_STATE;
            listContacts.Sort(delegate (AddressBookModel x, AddressBookModel y)
            {
                return (x.State.ToLower()).CompareTo((y.State.ToLower()));
            });
        }
        /// <summary>Sorts contact list by zip.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortByZip(List<AddressBookModel> listContacts)
        {
            sortType = SortingType.SORT_BY_ZIP;
            listContacts.Sort(delegate (AddressBookModel x, AddressBookModel y)
            {
                return (x.Zip).CompareTo((y.Zip));
            });
        }
        /// <summary>Sorts contact list on condition choosen.</summary>
        /// <param name="listContacts">The list contacts.</param>
        public static void SortOnConditionChooses(List<AddressBookModel> listContacts)
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