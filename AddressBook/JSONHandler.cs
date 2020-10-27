using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBook
{
    public class JSONHandler
    {
        static string filePathJSON = @"C:\Users\LENOVO\source\repos\AddressBook\AddressBook\AddressBookJSON.json";

        public static void WriteIntoJSONFile(Dictionary<string, List<Contacts>> sorted, string bookName)
        {
            Console.WriteLine("Writing Data into JSON File");

            foreach(KeyValuePair<string, List<Contacts>> kv in sorted)
            {
                string book = kv.Key;
                List<Contacts> contacts = kv.Value;

                if (book.Equals(bookName)) 
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                    using (StreamWriter stw = new StreamWriter(filePathJSON))
                    {
                        using (JsonTextWriter writer = new JsonTextWriter(stw))
                        {
                            serializer.Serialize(writer, contacts);
                        }
                    }
                }
            }
        }

        public static void ReadFromJSONFile()
        {
            Console.WriteLine("Reading Data from JSON File");

            //JsonConvert is from JSON.NET Library
            IList<Contacts> records = JsonConvert.DeserializeObject<IList<Contacts>>(File.ReadAllText(filePathJSON));

            foreach(Contacts record in records)
            {
                Console.WriteLine(record);
            }
        }

        public static void ClearData()
        {
            File.WriteAllText(filePathJSON, string.Empty);
        }
    }
}
