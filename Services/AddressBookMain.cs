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

        public void ViewByCity()
        {
            List<Contact> allContacts = books
            .SelectMany(b=> b.Contacts)
            .ToList();

            var groups = allContacts
                .GroupBy(c=>c.City)

            Console.WriteLine("--- By City ---"); 

            foreach(var group in groups)
            {
                Console.WriteLine(group.Key+":")
                foreach(Contact contact in group)
                {
                    Console.WriteLine(" " + contact.FirstName + " " + contact.LastName); 
                }
            }
        }

        public void ViewByState()
        {
            List<Contact> allContacts = books
            .SelectMany(b => b.Contacts)
            .ToList();

            var groups = allContacts
                .GroupBy(c => c.State)

            Console.WriteLine("--- By State ---");

            foreach (var group in groups)
            {
                Console.WriteLine(group.Key + ":")
                foreach (Contact contact in group)
                {
                    Console.WriteLine(" " + contact.FirstName + " " + contact.LastName);
                }
            }
        }

        public void GetCountByCity()
        {
            List<Contact> allContacts = books
                .Select(b => b.Contacts)
                .ToList();

            var cityCounts = allContacts
                .GroupBy(c => c.City)
                .Select(g => new
                {
                    City = g.Key
                    Count = g.Count()
                });


            Console.WriteLine("---Count By City---"); 

            foreach(var item in cityCounts)
            {
                Console.WriteLine($"{item.City} = {item.Count}");
            }
        }

        public void GetCountByState()
        {
            List<Contact> allContacts = books
                .Select(b => b.Contacts)
                .ToList();

            var stateCounts = allContacts
                .GroupBy(c => c.State)
                .Select(g => new
                {
                    State = g.Key
                    Count = g.Count()
                });


            Console.WriteLine("---Count By State---");

            foreach (var item in stateCounts)
            {
                Console.WriteLine($"{item.State} = {item.Count}");
            }
        }
    }
}
