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
                Console.WriteLine("2. Edit Contacts");
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

                    case 2:
                        Console.WriteLine("Enter the first name of the person: ");
                        string first = Console.ReadLine();
                        foreach(Contacts c in contacts)
                        {
                            if (c.first_name.Equals(first))
                            {
                                int n = 0;
                                while (n != 9)
                                {
                                    Console.WriteLine("Enter the following choice");
                                    Console.WriteLine("1. Edit First Name");
                                    Console.WriteLine("2. Edit Last Name");
                                    Console.WriteLine("3. Edit Address");
                                    Console.WriteLine("4. Edit City");
                                    Console.WriteLine("5. Edit State");
                                    Console.WriteLine("6. Edit Zip");
                                    Console.WriteLine("7. Edit Phone Number");
                                    Console.WriteLine("8. Edit E-mail");
                                    Console.WriteLine("9. Exit");
                                    Console.WriteLine("Enter your choice: ");
                                    n = Convert.ToInt32(Console.ReadLine());

                                    switch (n)
                                    {
                                        case 1:
                                            Console.WriteLine("1. Edit First Name");
                                            string fname = Console.ReadLine();
                                            c.first_name = fname;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 2:
                                            Console.WriteLine("1. Edit Last Name");
                                            string lname = Console.ReadLine();
                                            c.last_name = lname;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 3:
                                            Console.WriteLine("1. Edit Address Name");
                                            string adrss = Console.ReadLine();
                                            c.address = adrss;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 4:
                                            Console.WriteLine("1. Edit City Name");
                                            string cty = Console.ReadLine();
                                            c.city = cty;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 5:
                                            Console.WriteLine("1. Edit State");
                                            string ste = Console.ReadLine();
                                            c.state = ste;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 6:
                                            Console.WriteLine("1. Edit Zip");
                                            int zp = Convert.ToInt32(Console.ReadLine());
                                            c.zip = zp;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 7:
                                            Console.WriteLine("1. Edit Phone Number");
                                            long no = Convert.ToInt64(Console.ReadLine());
                                            c.phone = no;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                        case 8:
                                            Console.WriteLine("1. Edit Email");
                                            string mail = Console.ReadLine();
                                            c.first_name = mail;
                                            Console.WriteLine("Edited Successfully");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid name");
                            }
                        }
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
