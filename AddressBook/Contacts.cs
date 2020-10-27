using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class Contacts
    {
        public string first_name
        {
            set;
            get;
        }
        public string last_name
        {
            set;
            get;
        }
        public string address
        {
            set;
            get;
        }
        public string city
        {
            set;
            get;
        }
        public string state
        {
            set;
            get;
        }
        public int zip
        {
            set;
            get;
        }
        public long phone
        {
            set;
            get;
        }
        public string email
        {
            set;
            get;
        }

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

        public Contacts( )
        {
            
        }

        public override string ToString()
        {
            return "First Name: "+first_name+", "+"Last Name: "+last_name+", "+"Address: "+address+", "+"City: "+city+", "+"State: "+state+", "+"Zip: "+zip+", Phone Number: "+phone+", Email-id: "+email;
        }

        public void SortByName(List<Contacts> contacts)
        {
            contacts.Sort((contact1, contact2)=>contact1.first_name.CompareTo(contact2.first_name));
        }
        public void SortByCity(List<Contacts> contacts)
        {
            contacts.Sort((contact1, contact2)=> contact1.city.CompareTo(contact2.city));
        }
        public void SortByState(List<Contacts> contacts)
        {
            contacts.Sort((contact1, contact2)=> contact1.state.CompareTo(contact2.state));
        }
        public void SortByZip(List<Contacts> contacts)
        {
            contacts.Sort((contact1 ,contact2)=> contact1.zip.CompareTo(contact2.zip));
        }
    }
}
