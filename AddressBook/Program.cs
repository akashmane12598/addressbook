using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contacts> contacts=new List<Contacts>();

            Console.WriteLine("Welcome to Address Book Program");
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("Enter the following choice");
                Console.WriteLine("1. Add Contacts");
                Console.WriteLine("4. Display Contacts");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add New Contacts: ");
                        Console.WriteLine("Enter the firstname: ");
                        string first_name = Console.ReadLine();
                        Console.WriteLine("Enter the lastname: ");
                        string last_name = Console.ReadLine();
                        Console.WriteLine("Enter the address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter the city: ");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter the state: ");
                        string state = Console.ReadLine();
                        Console.WriteLine("Enter the zip: ");
                        int zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the phone number");
                        long phone = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the email: ");
                        string email = Console.ReadLine();

                        Contacts ct1 = new Contacts(first_name, last_name, address, city, state, zip, phone, email);
                        contacts.Add(ct1);
                        Console.WriteLine("Contact Added Successfully");
                        break;
                    
                    case 4:
                        foreach (Contacts c in contacts)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                }
            }


        }
    }
}
