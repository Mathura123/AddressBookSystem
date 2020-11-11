namespace AddressBookSystem
{
    using System;
    using System.Data.SqlClient;

    public class AddressBookDBWork
    {
        private static string connetionString = @"Data Source=DESKTOP-8UMNEFU\MSSQLSERVER01;Initial Catalog=address_book_service;Integrated Security=True";

        /// <summary>Retrives all contacts from database.</summary>
        /// <returns></returns>
        public static bool RetriveAllContactsFromDB()
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
        /// <summary>Stores all contacts to list.</summary>
        public static void StoreAllContactsToList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("RetriveContacts", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBookModel addressBookObj = new AddressBookModel();
                            addressBookObj.AddressBookName = dr.GetString(0);
                            addressBookObj.FirstName = dr.GetString(1);
                            addressBookObj.LastName = dr.GetString(2);
                            addressBookObj.Address = dr.GetString(3);
                            addressBookObj.City = dr.GetString(4);
                            addressBookObj.State = dr.GetString(5);
                            addressBookObj.Zip = dr.GetString(6);
                            addressBookObj.PhoneNo = dr.GetString(7);
                            addressBookObj.Email = dr.GetString(8);
                            Contacts.listContacts.Add(addressBookObj);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>Updates the contact.</summary>
        /// <param name="objAddressBook">The object address book.</param>
        public static bool UpdateContactInDB(AddressBookModel objAddressBook)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand($"update people_contact set Address = '{objAddressBook.Address}',City = '{objAddressBook.City}',State ='{objAddressBook.State}',Zipcode = '{objAddressBook.Zip}',PhoneNumber ='{objAddressBook.PhoneNo}',Email ='{objAddressBook.Email}' where FirstName= '{objAddressBook.FirstName}' and LastName = '{objAddressBook.LastName}'", connection);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    CustomPrint.PrintInRed($"{result} rows affected");
                    connection.Close();
                    if (result >= 1)
                        return true;
                    throw new AddressBookException(AddressBookException.ExceptionType.CONTACT_NOT_FOUND, "Contact not found");
                }
            }
            catch(AddressBookException ae)
            {
                Console.WriteLine(ae.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
