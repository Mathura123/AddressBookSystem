using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        [TestMethod]
        public void GetContactInGivenDateRange_ShouldReturn_False_IfNoContact_InGivenDateRange()
        {
            bool expected = false;
            bool result = AddressBookDBWork.GetContactInGivenDateRange(Convert.ToDateTime("12/10/2020"),Convert.ToDateTime("13/10/2020"));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetContactInGivenDateRange_ShouldReturn_True_IfContact_InGivenDateRange()
        {
            bool expected = true;
            bool result = AddressBookDBWork.GetContactInGivenDateRange(Convert.ToDateTime("10/11/2020"), DateTime.Now);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetContactsInGivenCity_ShouldReturn_True_IfContactsFound_InGivenCity()
        {
            bool expected = true;
            bool result = AddressBookDBWork.GetContactsInGivenCity("Pune", "Maharastra");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetContactsInGivenState_ShouldReturn_True_IfContactsFound_InGivenState()
        {
            bool expected = true;
            bool result = AddressBookDBWork.GetContactsInGivenState("UP");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AddContactInDb_ShouldReturn_True_AfterAdding_TheContact()
        {
            bool expected = true;
            AddressBookModel objModel = new AddressBookModel();
            objModel.FirstName = "Radha";
            objModel.LastName = "Gupta";
            objModel.Address = "Sector 90";
            objModel.City = "Noida";
            objModel.State = "UP";
            objModel.PhoneNo = "9878987898";
            objModel.Zip = "121212";
            objModel.Email = "radha@exp.com";
            objModel.AddressBookName = "a4";
            objModel.DateAdded = DateTime.Now;
            bool result = AddressBookDBWork.AddContactToDB(objModel);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AddMultipleAddressBook_Should_Be_Able_ToAdd_AddressBooks()
        {
            List<AddressBookModel> modelList = new List<AddressBookModel>
            {
                new AddressBookModel(){ FirstName ="Hardy", LastName = "Sindu" ,Address = null, City = "Mumbai",State= "Maharastra", Zip = "888888", PhoneNo = "8888888888", Email= "har@abc.com"},
                new AddressBookModel(){ FirstName ="Harshit", LastName = "Gupta" ,Address = null, City = "Mumbai",State= "Maharastra", Zip = "888888", PhoneNo = "8888888888", Email= "har@abc.com"},
                new AddressBookModel(){ FirstName ="Ram", LastName = "Manohar" ,Address = null, City = "Mumbai",State= "Maharastra", Zip = "888888", PhoneNo = "8888888888", Email= "har@abc.com"},
                new AddressBookModel(){ FirstName ="Abishey", LastName = "Anand" ,Address = "I90/78", City = "Mumbai",State= "Maharastra", Zip = "888888", PhoneNo = "8888888888", Email= "har@abc.com"},
        };
            DateTime startDateTime = DateTime.Now;
            AddressBookDBWork.AddMultipleContactsToDB(modelList);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (startDateTime - stopDateTime));
        }
    }
}
