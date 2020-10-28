namespace AddressBookSystem
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddressBookDetailsValidation
    {
        //For validating AddressBookName and person details
        public static bool Validate(object obj)
        {
            ValidationContext context = new ValidationContext(obj);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(obj, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult TotalResult in results)
                {
                    Contacts.PrintInMagenta($"Error Msg : {TotalResult.ErrorMessage}");
                }
                Contacts.PrintInMagenta($"Try Again");
                return false;
            }
            else
                return true;
        }
    }
}