using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookException : Exception
    {
        public enum ExceptionType
        {
            CONTACT_NOT_FOUND,
            No_DATA_IN_GIVEN_DATE_RANGE,
            INCORRECT_DETAIL,
            INVALID_DATE
        }
        private ExceptionType type;
        public AddressBookException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
