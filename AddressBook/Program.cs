using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBook
{
    public class Program
    {
        public static string filePath=@"C:\Users\LENOVO\source\repos\AddressBook\AddressBook\AddressBook.txt";

        public static void Main(string[] args)
        {
            Dictionary<String, List<Contacts>> sorted = new Dictionary<String, List<Contacts>>();
            int c1 = 0;
            while (c1 != 11)
            {
                string bname="";
                Console.WriteLine("Welcome to Address Book Program");
                List<Contacts> gcontacts = new List<Contacts>();   //stores contacts list for different address books
                
                Console.WriteLine("1. Add Address Book: ");
                Console.WriteLine("2. Edit a Particular Address Book: ");
                Console.WriteLine("3. Display Address Book: ");
                Console.WriteLine("4. View Person's Details By City: ");
                Console.WriteLine("5. View Person's Details By State: ");
                Console.WriteLine("6. Write Address Book into a File: ");
                Console.WriteLine("7. Read Address Book from a File: ");
                Console.WriteLine("8. Write and Read Address Book(CSV File): ");
                Console.WriteLine("9. Write and Read Address Book(JSON File): ");
                Console.WriteLine("10. Clear Address Book Details from all Files(Txt, CSV, JSON): ");
                Console.WriteLine("11. Exit");

                Console.WriteLine("Enter your choice: ");
                c1 = Convert.ToInt32(Console.ReadLine());
                switch (c1)
                {
                    case 1:
                        Console.WriteLine("Enter the name of Address Book: ");
                        bname = Console.ReadLine();
                        List<Contacts> contacts = new List<Contacts>();  //stores contacts list for a particular book
                        
                        AddressBookMainLogic.edit_data(contacts);
                        
                        gcontacts.AddRange(contacts);
                        sorted.Add(bname, gcontacts);
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of Address Book: ");
                        string bname1 = Console.ReadLine();
                        if (sorted.ContainsKey(bname1))
                        {
                            List<Contacts> edit =sorted[bname1];
                            AddressBookMainLogic.edit_data(edit);
                        }
                        else
                        {
                            Console.WriteLine("Mentioned Address Book is not there");
                        }
                        break;
                    case 3:
                        foreach (KeyValuePair<String, List<Contacts>> kv in sorted)
                        {
                            string a = kv.Key;
                            List<Contacts> list1 = (List<Contacts>)kv.Value;
                            Console.WriteLine("Address Book Name: " + a);
                            foreach (Contacts c in list1)
                            {
                                Console.WriteLine(c);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the City Name: ");
                        string city = Console.ReadLine();
                        int fg = 0;

                        Dictionary<string, List<Contacts>> cty = new Dictionary<string, List<Contacts>>();
                        List<Contacts> gtemp = new List<Contacts>();

                        foreach (KeyValuePair<string, List<Contacts>> kv in sorted)
                        {
                            List<Contacts> list1 = kv.Value; //gives list details per address book
                            List<Contacts> temp = new List<Contacts>();
                            foreach (Contacts c in list1)
                            {
                                if (c.city.ToLower().Equals(city.ToLower()))
                                {
                                    temp.Add(c);
                                    fg++;
                                }
                            }
                            gtemp.AddRange(temp);            //Appends person's details per book by city               
                        }
                        cty.Add(city, gtemp);

                        if (fg == 0)
                        {
                            Console.WriteLine("Mentioned City Name isn't present in Address Book");
                        }
                        else
                        {
                            Console.WriteLine("Total records for City Name " + city + ": " + fg);
                            foreach (KeyValuePair<string, List<Contacts>> kv in cty)
                            {
                                string a = kv.Key;
                                List<Contacts> lst = kv.Value;
                                Console.WriteLine("City Name: " + a);
                                foreach (Contacts c in lst)
                                {
                                    Console.WriteLine(c);
                                }
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter the State Name: ");
                        string state = Console.ReadLine();
                        int fg1 = 0;

                        Dictionary<string, List<Contacts>> st = new Dictionary<string, List<Contacts>>();
                        List<Contacts> gtemp1 = new List<Contacts>();

                        foreach (KeyValuePair<string, List<Contacts>> kv in sorted)
                        {
                            List<Contacts> list1 = kv.Value; //gives list details per address book
                            List<Contacts> temp = new List<Contacts>();
                            foreach (Contacts c in list1)
                            {
                                if (c.state.ToLower().Equals(state.ToLower()))
                                {
                                    temp.Add(c);
                                    fg1++;
                                }
                            }
                            gtemp1.AddRange(temp);            //Appends person's details per book by state               
                        }
                        st.Add(state, gtemp1);

                        if (fg1 == 0)
                        {
                            Console.WriteLine("Mentioned State Name isn't present in Address Book");
                        }
                        else
                        {
                            Console.WriteLine("Total records for State Name " + state + ": " + fg1);
                            foreach (KeyValuePair<string, List<Contacts>> kv in st)
                            {
                                string a = kv.Key;
                                List<Contacts> lst = kv.Value;
                                Console.WriteLine("City Name: " + a);
                                foreach (Contacts c in lst)
                                {
                                    Console.WriteLine(c);
                                }
                            }
                        }

                        break;
                    case 6:
                        if (File.Exists(filePath))
                        {
                            using (StreamWriter stw = File.CreateText(filePath))
                            {
                                foreach (KeyValuePair<String, List<Contacts>> kv in sorted)
                                {
                                    string a = kv.Key;
                                    List<Contacts> list1 = (List<Contacts>)kv.Value;
                                    stw.WriteLine("Address Book Name: " + a);
                                    foreach (Contacts c in list1)
                                    {
                                        stw.WriteLine(c);
                                    }
                                }
                                Console.WriteLine("Address Book written into the file successfully!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                        break;
                    case 7:
                        if (File.Exists(filePath))
                        {
                            using (StreamReader str = File.OpenText(filePath))
                            {
                                string s = "";
                                while ((s = str.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter the Address Book Name:");
                        string nameCSV = Console.ReadLine();
                        if (sorted.ContainsKey(nameCSV))
                        {
                            CSVHandler.WriteIntoCSVFile(sorted, nameCSV);
                            Console.WriteLine("Data inserted successfully");
                            CSVHandler.ReadFromCSVFile();
                            Console.WriteLine("Data read successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Enter the Address Book Name:");
                        string nameJSON = Console.ReadLine();
                        if (sorted.ContainsKey(nameJSON))
                        {
                            JSONHandler.WriteIntoJSONFile(sorted, nameJSON);
                            Console.WriteLine("Data inserted successfully");
                            JSONHandler.ReadFromJSONFile();
                            Console.WriteLine("Data read successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                        break;
                    case 10:
                        File.WriteAllText(filePath, string.Empty);
                        CSVHandler.ClearData();
                        JSONHandler.ClearData();
                        Console.WriteLine("All Files cleared successfully!!!");
                        break;                   
                }

            }
        }       
    }
}
