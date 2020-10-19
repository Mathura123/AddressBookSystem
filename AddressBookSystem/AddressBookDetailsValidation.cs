using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    public class AddressBookDetailsValidation
    {
        public static void ValidateAddressBookName(string addressBookName)
        {
            WorkingOnAddressBook addressBookObj = new WorkingOnAddressBook();
            addressBookObj.AddressBookName = addressBookName;
            ValidationContext context = new ValidationContext(addressBookObj);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(addressBookObj, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult TotalResult in results)
                {
                    Console.WriteLine("Error Msg : {0}{1}", TotalResult.ErrorMessage, Environment.NewLine);
                }
                Console.WriteLine("Try Again\n");
                WorkingOnAddressBook.AddressBook();
            }
        }
        public static bool ValidatePersonDetails(string firstName,string lastName,string phoneNo,string email)
        {
            Contacts contactObj = new Contacts();
            contactObj.FirstName = firstName;
            contactObj.LastName = lastName;
            contactObj.PhoneNo = phoneNo;
            contactObj.Email = email;
            ValidationContext context = new ValidationContext(contactObj);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(contactObj, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult TotalResult in results)
                {
                    Console.WriteLine("\nError Msg : {0}", TotalResult.ErrorMessage);
                }
                Console.WriteLine("\nTry Again\nContacts not Added\n");
                return false;
            }
            else
                return true;
        }
    }
}