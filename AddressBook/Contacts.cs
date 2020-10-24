using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts:IComparable
    {
        public string first_name;
        public string last_name;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phone;
        public string email;

        public Contacts(string first_name, string last_name, string address, string city, string state, int zip, long phone, string email)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone = phone;
            this.email = email;
        }

        public override string ToString()
        {
            return "First Name: "+first_name+", "+"Last Name: "+last_name+", "+"Address: "+address+", "+"City: "+city+", "+"State: "+state+", "+"Zip: "+zip+", Phone Number: "+phone+", Email-id: "+email;
        }

        public int CompareTo(object obj)
        {
            Contacts c = (Contacts)obj;
            return this.first_name.CompareTo(c.first_name);
        }
    }
}
