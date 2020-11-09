using AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// UC22 RetrieveDataFromJSONServer
        /// </summary>
        [TestMethod]
        public void RetrieveDataFromJSONServer()
        {
            RestRequest request = new RestRequest("/contacts", Method.GET);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            List<Contacts> contacts = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);

            Assert.AreEqual(3, contacts.Count);

            foreach(Contacts c in contacts)
            {
                Console.WriteLine(c);
            }

        }

        /// <summary>
        /// UC23 AddContactsToJSONServer
        /// </summary>
        [TestMethod]
        public void AddContactsToJSONServer()
        {
            RestRequest request = new RestRequest("/contacts", Method.POST);

            JObject jObject = new JObject();
            jObject.Add("first_name", "Rohit");
            jObject.Add("last_name", "Sharma");
            jObject.Add("address", "Mumbai");
            jObject.Add("city", "Worli");
            jObject.Add("state", "Maharashtra");
            jObject.Add("zip", 400004);
            jObject.Add("phone", 106098752);
            jObject.Add("email", "rohit@gmail.com");

            request.AddParameter("application/json", jObject, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);

            Contacts contacts = JsonConvert.DeserializeObject<Contacts>(response.Content);

            Assert.AreEqual("Rohit", contacts.first_name);
            Assert.AreEqual("Sharma", contacts.last_name);
            Assert.AreEqual("Mumbai", contacts.address);
            Assert.AreEqual("Worli", contacts.city);
            Assert.AreEqual("Maharashtra", contacts.state);
            Assert.AreEqual(400004, contacts.zip);
            Assert.AreEqual(106098752, contacts.phone);
            Assert.AreEqual("rohit@gmail.com", contacts.email);

            Console.WriteLine(response.Content);

        }
    }
}
