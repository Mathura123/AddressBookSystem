namespace AddressBookSystem
{
    using System.Collections.Generic;

    class AddressBookMain
    {
        /// <summary>The address book dictionary</summary>
        public static Dictionary<string, AddressBookModel> addressBookDict = new Dictionary<string, AddressBookModel>();
        public static void Main()
        {
            CustomPrint.PrintInRed("*****Welcome to Address Book Program*****", false);
            //For storing saved data from file in listContacts
            AddressBookDBWork.StoreAllContactsToList();
            //Calling AddressBook Method for Choosing Option
            WorkingOnAddressBook.AddressBook();
        }
    }
}
