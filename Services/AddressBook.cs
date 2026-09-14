using System;
using System.Collections.Generic;
using System.Text;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new();

        public IReadOnlyList<Contact> Contacts => contacts;

        public void AddContact(Contact contact)
        {
            ContactValidator.Validate(contact);

            contacts.Add(contact);

            Console.WriteLine("Contact added successfully.");
        }

        public void PrintAll()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
