using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBookUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Correct_AddressBookName_Should_Return_True_In_ValidateAddressBookName()
        {
            bool expected = true;
            string addressBookName = "A1";
            bool result =AddressBookDetailsValidation.ValidateAddressBookName(addressBookName);
            Assert.AreEqual(result, expected);
        }
    }
}
