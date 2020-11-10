using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace AddressBookSystem
{
    public class AddressBookDBWork
    {
        private string connetionString = @"Data Source=DESKTOP-8UMNEFU\MSSQLSERVER01;Initial Catalog=address_book_service;Integrated Security=True";

        /// <summary>Retrives all contacts from database.</summary>
        /// <returns></returns>
        public bool RetriveAllContactsFromDB()
        {
            try
            {
                AddressBookModel addressBookObj = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("RetriveContacts", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed("All Contacts from DB");
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email"));
                        CustomPrint.PrintDashLine();
                        while (dr.Read())
                        {
                            addressBookObj.AddressBookName = dr.GetString(0);
                            addressBookObj.FirstName = dr.GetString(1);
                            addressBookObj.LastName = dr.GetString(2);
                            addressBookObj.Address = dr.GetString(3);
                            addressBookObj.City = dr.GetString(4);
                            addressBookObj.State = dr.GetString(5);
                            addressBookObj.Zip = dr.GetString(6);
                            addressBookObj.PhoneNo = dr.GetString(7);
                            addressBookObj.Email = dr.GetString(8);
                            Console.WriteLine(addressBookObj);
                        }
                        CustomPrint.PrintDashLine();
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
