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
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Error Msg : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{TotalResult.ErrorMessage}\n");
                    Console.ResetColor();
                }
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Try Again");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------");
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
                    Console.WriteLine("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Error Msg : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{TotalResult.ErrorMessage}\n");
                    Console.ResetColor();
                }
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Try Again");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------");
                return false;
            }
            else
                return true;
        }
    }
}