using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

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

    }
}
