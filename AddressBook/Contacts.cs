using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts
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

    }
}
