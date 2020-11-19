namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

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
                        Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
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
                            addressBookObj.DateAdded = dr.GetDateTime(9);
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
                CustomPrint.PrintInMagenta(e.Message);
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
                            addressBookObj.DateAdded = dr.GetDateTime(9);
                            Contacts.listContacts.Add(addressBookObj);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
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
            catch (AddressBookException ae)
            {
                CustomPrint.PrintInMagenta(ae.Message);
                return false;
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets the contacts in given date range.</summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool GetContactInGivenDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                AddressBookModel addressBookObj = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand($"select AddressBookName, pc.FirstName,pc.LastName,Address,City,State,Zipcode,PhoneNumber,Email,date_added " +
                        $"from address_book_person_name adp inner join people_contact pc " +
                        $"on adp.FirstName = pc.FirstName and adp.LastName = pc.LastName " +
                        $"where date_added between '{startDate.Year}-{startDate.Month}-{startDate.Day}' and '{endDate.Year}-{endDate.Month}-{endDate.Day}'", connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"All Contacts from DB in between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}");
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
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
                            addressBookObj.DateAdded = dr.GetDateTime(9);
                            Console.WriteLine(addressBookObj);
                        }
                        CustomPrint.PrintDashLine();
                        connection.Close();
                        return true;
                    }
                    throw new AddressBookException(AddressBookException.ExceptionType.No_DATA, "No Contacts in Given Date Range");
                }
            }
            catch (AddressBookException e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets the contacts in given city.</summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="AddressBookException">No Contacts in Given City</exception>
        public static bool GetContactsInGivenCity(string city, string state)
        {
            try
            {
                AddressBookModel addressBookObj = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand($"select AddressBookName, pc.FirstName,pc.LastName,Address,City,State,Zipcode,PhoneNumber,Email,date_added " +
                        $"from address_book_person_name adp inner join people_contact pc " +
                        $"on adp.FirstName = pc.FirstName and adp.LastName = pc.LastName " +
                        $"where City = '{city}' and State = '{state}'", connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"All Contacts from DB in city {city}");
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
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
                            addressBookObj.DateAdded = dr.GetDateTime(9);
                            Console.WriteLine(addressBookObj);
                        }
                        CustomPrint.PrintDashLine();
                        connection.Close();
                        return true;
                    }
                    throw new AddressBookException(AddressBookException.ExceptionType.No_DATA, "No Contacts in Given City");
                }
            }
            catch (AddressBookException e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets the state of the contacts in given.</summary>
        /// <param name="state">The state.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="AddressBookException">No Contacts in Given State</exception>
        public static bool GetContactsInGivenState(string state)
        {
            try
            {
                AddressBookModel addressBookObj = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand($"select AddressBookName, pc.FirstName,pc.LastName,Address,City,State,Zipcode,PhoneNumber,Email,date_added " +
                        $"from address_book_person_name adp inner join people_contact pc " +
                        $"on adp.FirstName = pc.FirstName and adp.LastName = pc.LastName " +
                        $"where State = '{state}'", connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"All Contacts from DB in state {state}");
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("AddressBookName", "Name", "Address", "City", "State", "Zip", "PhoneNo", "Email", "Date Added"));
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
                            addressBookObj.DateAdded = dr.GetDateTime(9);
                            Console.WriteLine(addressBookObj);
                        }
                        CustomPrint.PrintDashLine();
                        connection.Close();
                        return true;
                    }
                    throw new AddressBookException(AddressBookException.ExceptionType.No_DATA, "No Contacts in Given State");
                }
            }
            catch (AddressBookException e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Adds the contact to database.</summary>
        /// <param name="addressBookObj">The address book object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool AddContactToDB(AddressBookModel addressBookObj)
        {
            bool result;
            try
            {
                SqlTransaction objTrans = null;
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();
                    objTrans = connection.BeginTransaction();
                    SqlCommand command1 = new SqlCommand($"insert into people_contact values" +
                        $"('{addressBookObj.FirstName}','{addressBookObj.LastName}','{addressBookObj.Address}','" +
                        $"{addressBookObj.City}','{addressBookObj.State}','{addressBookObj.Zip}','{addressBookObj.PhoneNo}','" +
                        $"{addressBookObj.Email}','{addressBookObj.DateAdded.Year}-{addressBookObj.DateAdded.Month}-{addressBookObj.DateAdded.Day}')", connection, objTrans);
                    SqlCommand command2 = new SqlCommand($"insert into address_book_person_name values" +
                        $"('{addressBookObj.AddressBookName}','{addressBookObj.FirstName}','{addressBookObj.LastName}')", connection, objTrans);
                    try
                    {
                        int noOfRow1 = command1.ExecuteNonQuery();
                        int noOfRow2 = command2.ExecuteNonQuery();
                        objTrans.Commit();
                        CustomPrint.PrintInRed($"{noOfRow2} rows affected");
                        result = true;
                    }
                    catch (Exception e)
                    {
                        CustomPrint.PrintInMagenta(e.Message);
                        objTrans.Rollback();
                        result = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                result = false;
            }
            return result;
        }
        /// <summary>Adds the multiple contacts to database.</summary>
        /// <param name="addressBookList">The address book list.</param>
        public static void AddMultipleContactsToDB(List<AddressBookModel> addressBookList)
        {
            addressBookList.ForEach(addressBook =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Address Book being added for : " + addressBook.FirstName + " "+ addressBook.LastName);
                    bool result =AddContactToDB(addressBook);
                    if (result)
                        Console.WriteLine("Address Book added for : " + addressBook.FirstName + " " + addressBook.LastName);
                    else
                        Console.WriteLine("Address Book could not add " + addressBook.FirstName + " " + addressBook.LastName);
                }
                );
                thread.Start();
                thread.Wait();
            });
        }
        /// <summary>Deletes the contact from database.</summary>
        /// <param name="addressBookObj">The address book object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool DeleteContactFromDB(AddressBookModel addressBookObj)
        {
            bool result;
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"delete from people_contact " +
                        $"where FirstName = '{addressBookObj.FirstName}' and LastName = '{addressBookObj.LastName}'", connection);
                    int noOfRow = command.ExecuteNonQuery();
                    CustomPrint.PrintInRed($"{noOfRow} rows affected");
                    result = true;
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                result = false;
            }
            return result;
        }
    }
}
