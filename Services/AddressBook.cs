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

        public void EditContact(string firstName, string lastName)
        {
            Contact contact = contacts.Find(
                c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
                  && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
            );

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Editing: " + contact);

            Console.Write("Enter new first name (or press Enter to keep): ");
            string firstNameInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(firstNameInput))
            {
                contact.FirstName = firstNameInput;
            }

            Console.Write("Enter new last name (or press Enter to keep): ");
            string lastNameInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(lastNameInput))
            {
                contact.LastName = lastNameInput;
            }

            Console.Write("Enter new address (or press Enter to keep): ");
            string addressInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(addressInput))
            {
                contact.Address = addressInput;
            }

            Console.Write("Enter new city (or press Enter to keep): ");
            string cityInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(cityInput))
            {
                contact.City = cityInput;
            }

            Console.Write("Enter new state (or press Enter to keep): ");
            string stateInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(stateInput))
            {
                contact.State = stateInput;
            }

            Console.Write("Enter new zip (or press Enter to keep): ");
            string zipInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(zipInput))
            {
                contact.Zip = zipInput;
            }

            Console.Write("Enter new phone (or press Enter to keep): ");
            string phoneInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(phoneInput))
            {
                contact.PhoneNumber = phoneInput;
            }

            Console.Write("Enter new email (or press Enter to keep): ");
            string emailInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(emailInput))
            {
                contact.Email = emailInput;
            }

            ContactValidator.Validate(contact);

            Console.WriteLine("Contact updated.");
        }
    }
}
