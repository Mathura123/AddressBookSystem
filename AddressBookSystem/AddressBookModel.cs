using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    public class AddressBookModel
    {
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

        public AddressBookModel()
        {
        }
        public AddressBookModel(string[] personDetail)
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

        public override string ToString()
        {
            string name = FirstName + " " + LastName;
            return CustomPrint.PrintRow(AddressBookName, name, Address, City, State, Zip, PhoneNo, Email);
        }
    }
}
