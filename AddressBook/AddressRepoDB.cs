﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    public class AddressRepoDB
    {
        public static string connectionString = @"Data Source=(Localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";

        static SqlConnection connection;

        /// <summary>
        /// UC16 RetrieveDataFromDB
        /// </summary>
        /// <returns></returns>
        public static ContactsDB RetrieveData()
        {
            try
            {
                connection = new SqlConnection(connectionString);

                ContactsDB contactsDB = new ContactsDB();

                string query = "select c.FirstName, c.LastName, c.City, c.PhoneNumber, bk.B_Name, bk.B_Type from Contacts c inner join BookNameType bk on c.B_ID=bk.B_ID where c.FirstName='Akash'";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contactsDB.first_name = reader.GetString(0);
                        contactsDB.last_name = reader.GetString(1);
                        contactsDB.city = reader.GetString(2);
                        contactsDB.phone = reader.GetString(3);
                        contactsDB.B_Name = reader.GetString(4);
                        contactsDB.B_Type = reader.GetString(5);
                    }                   
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();               

                return contactsDB;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// UC17 UpdateDetailsInDB
        /// </summary>
        /// <returns></returns>
        public static string UpdateDetailsInDB()
        {
            string state = "";
            try
            {
                connection = new SqlConnection(connectionString);
                string query = "update Contacts set State='Gujarat' where FirstName='Akhil'; select * from Contacts where FirstName='Akhil'";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        state = reader.GetString(4);
                    }
                }
                else
                {
                    Console.WriteLine("Row isn't updated");
                }
                reader.Close();
                return state;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return state;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// UC19 RetrieveDataByCityorState
        /// </summary>
        public static void RetrieveDataByCityorState()
        {
            ContactsDB contactsDB = new ContactsDB();

            try
            {

                connection = new SqlConnection(connectionString);
                string query = "select c.FirstName, c.LastName, c.City, c.State, c.PhoneNumber, bk.B_Name, bk.B_Type from Contacts c inner join BookNameType bk on c.B_ID=bk.B_ID where City='Mulund' or State='Bengal'";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contactsDB.first_name = reader.GetString(0);
                        contactsDB.last_name = reader.GetString(1);
                        contactsDB.city = reader.GetString(2);
                        contactsDB.state = reader.GetString(3);
                        contactsDB.phone = reader.GetString(4);
                        contactsDB.B_Name = reader.GetString(5);
                        contactsDB.B_Type = reader.GetString(6);
                        Console.WriteLine("FirstName: " + contactsDB.first_name + ", LastName: " + contactsDB.last_name + ", City: " + contactsDB.city + ", State: " + contactsDB.state + ", Phone: " + contactsDB.phone + ", BookName: " + contactsDB.B_Name + ", BookType: " + contactsDB.B_Type);
                        Console.WriteLine();                    
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
