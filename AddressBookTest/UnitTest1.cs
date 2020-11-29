using AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        /// <summary>
        /// UC16
        /// </summary>
        [TestMethod]
        public void CompareRetrievedDataFromDB()
        {
            ContactsDB expected = new ContactsDB()
            {
                first_name="Akash",
                last_name="Mane",
                city="Mulund",
                phone= "1234567890",
                B_Name= "Book1",
                B_Type= "Family"
            };

            var actual = AddressRepoDB.RetrieveData();

            Assert.AreEqual(expected.first_name, actual.first_name);
            Assert.AreEqual(expected.last_name, actual.last_name);
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.phone, actual.phone);
            Assert.AreEqual(expected.B_Name, actual.B_Name);
            Assert.AreEqual(expected.B_Type, actual.B_Type);

        }

        /// <summary>
        /// UC17 
        /// </summary>
        [TestMethod]
        public void CompareUpdatedDataFromDB()
        {
            string expected = "Gujarat";

            string actual = AddressRepoDB.UpdateDetailsInDB();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveDataFromJSONServer()
        {
            RestRequest request = new RestRequest("/contacts", Method.GET);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            List<Contacts> contacts = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);

            foreach(Contacts c in contacts)
            {
                Console.WriteLine(c);
            }

        }
    }
}
