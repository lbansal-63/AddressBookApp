using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new();

        public IReadOnlyList<Contact> Contacts => contacts;

        // UC3 + UC7
        public void AddContact(Contact contact)
        {
            ContactValidator.Validate(contact);

            bool exists = contacts.Any(
                c => c.FirstName.Equals(
                        contact.FirstName,
                        StringComparison.OrdinalIgnoreCase
                     )
                     &&
                     c.LastName.Equals(
                        contact.LastName,
                        StringComparison.OrdinalIgnoreCase
                     )
            );

            if (exists)
            {
                Console.WriteLine(
                    $"Contact '{contact.FirstName} {contact.LastName}' already exists. Duplicate not added."
                );

                return;
            }

            contacts.Add(contact);

            Console.WriteLine("Contact added successfully.");
        }

        // UC3
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

        // UC4
        public void EditContact(string firstName, string lastName)
        {
            Contact contact = contacts.Find(
                c => c.FirstName.Equals(
                        firstName,
                        StringComparison.OrdinalIgnoreCase
                     )
                     &&
                     c.LastName.Equals(
                        lastName,
                        StringComparison.OrdinalIgnoreCase
                     )
            );

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Editing: " + contact);

            Console.Write("Enter new first name: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.FirstName = input;

            Console.Write("Enter new last name: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.LastName = input;

            Console.Write("Enter new address: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.Address = input;

            Console.Write("Enter new city: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.City = input;

            Console.Write("Enter new state: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.State = input;

            Console.Write("Enter new zip: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.Zip = input;

            Console.Write("Enter new phone: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.PhoneNumber = input;

            Console.Write("Enter new email: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                contact.Email = input;

            ContactValidator.Validate(contact);

            Console.WriteLine("Contact updated.");
        }

        // UC5
        public void DeleteContact(string firstName, string lastName)
        {
            Contact contact = contacts.Find(
                c => c.FirstName.Equals(
                        firstName,
                        StringComparison.OrdinalIgnoreCase
                     )
                     &&
                     c.LastName.Equals(
                        lastName,
                        StringComparison.OrdinalIgnoreCase
                     )
            );

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(contact);

            Console.WriteLine("Contact deleted.");
        }

        // UC11
        public void SortByName()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        // UC12
        public void SortByCity()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.City);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        // UC12
        public void SortByState()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.State);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        // UC12
        public void SortByZip()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.Zip);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}