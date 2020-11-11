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
            WorkingOnAddressBook addressBookObj = new WorkingOnAddressBook();
            addressBookObj.AddressBookName = addressBookName;
            bool result =AddressBookDetailsValidation.Validate(addressBookObj);
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void RetriveContactsFromDB_ShouldReturn_True_IfContactsRecieved()
        {
            bool expected = true;
            bool result = AddressBookDBWork.RetriveAllContactsFromDB();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void UpdateContactInDB_ShouldReturn_False_IfContactsNotFound()
        {
            bool expected = false;
            AddressBookModel modelObj = new AddressBookModel();
            modelObj.FirstName = "Rakesh";
            modelObj.LastName = "Kumar";
            modelObj.Address = "Street 67,Navi Mumbai, Maharastra";
            modelObj.City = "Mumbai";
            modelObj.State = "Maharastra";
            modelObj.Zip = "951245";
            modelObj.PhoneNo = "9865326578";
            bool result = AddressBookDBWork.UpdateContactInDB(modelObj);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void UpdateContactInDB_ShouldReturn_True_IfContactFound_And_ContactGotUpdated()
        {
            bool expected = true;
            AddressBookModel modelObj = new AddressBookModel();
            modelObj.FirstName = "Rakesh";
            modelObj.LastName = "Mehta";
            modelObj.Address = "Street 67,Navi Mumbai, Maharastra";
            modelObj.City = "Mumbai";
            modelObj.State = "Maharastra";
            modelObj.Zip = "951245";
            modelObj.PhoneNo = "9865326578";
            modelObj.Email = "rakesh@exp.com";
            bool result = AddressBookDBWork.UpdateContactInDB(modelObj);
            Assert.AreEqual(expected, result);
        }
    }
}
