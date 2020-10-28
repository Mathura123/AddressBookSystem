namespace AddressBookSystem
{
    using System.Collections.Generic;

    class AddressBookMain
    {
        public static Dictionary<string, Contacts> addressBookDict = new Dictionary<string, Contacts>();
        public static void Main()
        {
            Contacts.PrintInRed("*****Welcome to Address Book Program*****", false);
            //Calling AddressBook Method for Choosing Option
            AddressBookFileIO.StoreAddressBookDetailsInContactsList();
            WorkingOnAddressBook.AddressBook();
        }
    }
}
