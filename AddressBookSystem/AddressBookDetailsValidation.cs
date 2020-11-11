namespace AddressBookSystem
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

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
                    try
                    {
                        throw new AddressBookException(AddressBookException.ExceptionType.INCORRECT_DETAIL, $"Error Msg : {TotalResult.ErrorMessage}");
                    }
                    catch (AddressBookException ae)
                    {
                        CustomPrint.PrintInMagenta(ae.Message);
                    }
                }
                CustomPrint.PrintInMagenta($"Try Again");
                return false;
            }
            else
                return true;
        }

    }
}