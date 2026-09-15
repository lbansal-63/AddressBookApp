using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AddressBookApp.Models; 

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new(); 

        public void AddAddressBook(AddressBook book)
        {
            books.Add(book); 
        }

        public int GetTotalContactCount()
        {
            return books.Sum(b=>b.Contacts.Count);
        }

        public List<AddressBook> GetAddressBooks()
        {
            return books; 
        }

        public List<Contact> SearchByCity(string city)
        {
            return books
            .SelectMany(b => b.Contacts)
            .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
        public List<Contact> SearchByState(string state)
        {
            return books
            .SelectMany(b => b.Contacts)
            .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }

    }
}
