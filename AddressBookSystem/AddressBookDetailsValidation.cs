using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    public class AddressBookDetailsValidation
    {
        public static bool ValidateAddressBookName(WorkingOnAddressBook addressBookObj)
        {
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
                return false;
            }
            else
                return true;
        }
        public static bool ValidatePersonDetails(Contacts contactObj)
        {
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