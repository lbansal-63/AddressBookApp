using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookApp.Models;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new();


        // ==========================================
        // UC6 - ADD ADDRESS BOOK
        // ==========================================

        public void AddAddressBook(
            AddressBook book)
        {
            books.Add(book);
        }


        // ==========================================
        // UC6 - TOTAL CONTACT COUNT
        // ==========================================

        public int GetTotalContactCount()
        {
            return books.Sum(
                b => b.Contacts.Count
            );
        }


        // ==========================================
        // UC8 - SEARCH BY CITY
        // ==========================================

        public List<Contact> SearchByCity(
            string city)
        {
            return books
                .SelectMany(b => b.Contacts)
                .Where(
                    c => c.City.Equals(
                        city,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .ToList();
        }


        // ==========================================
        // UC8 - SEARCH BY STATE
        // ==========================================

        public List<Contact> SearchByState(
            string state)
        {
            return books
                .SelectMany(b => b.Contacts)
                .Where(
                    c => c.State.Equals(
                        state,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .ToList();
        }


        // ==========================================
        // UC9 - VIEW BY CITY
        // ==========================================

        public void ViewByCity()
        {
            var allContacts = books
                .SelectMany(b => b.Contacts)
                .ToList();

            var groups = allContacts
                .GroupBy(c => c.City);

            Console.WriteLine(
                "--- Contacts By City ---"
            );

            foreach (var group in groups)
            {
                Console.WriteLine(
                    group.Key + ":"
                );

                foreach (Contact contact in group)
                {
                    Console.WriteLine(
                        $"  {contact.FirstName} {contact.LastName}"
                    );
                }
            }
        }


        // ==========================================
        // UC9 - VIEW BY STATE
        // ==========================================

        public void ViewByState()
        {
            var allContacts = books
                .SelectMany(b => b.Contacts)
                .ToList();

            var groups = allContacts
                .GroupBy(c => c.State);

            Console.WriteLine(
                "--- Contacts By State ---"
            );

            foreach (var group in groups)
            {
                Console.WriteLine(
                    group.Key + ":"
                );

                foreach (Contact contact in group)
                {
                    Console.WriteLine(
                        $"  {contact.FirstName} {contact.LastName}"
                    );
                }
            }
        }


        // ==========================================
        // UC10 - COUNT BY CITY
        // ==========================================

        public void GetCountByCity()
        {
            var allContacts = books
                .SelectMany(b => b.Contacts)
                .ToList();

            var cityCounts = allContacts
                .GroupBy(c => c.City)
                .Select(
                    g => new
                    {
                        City = g.Key,
                        Count = g.Count()
                    }
                );

            Console.WriteLine(
                "--- Contact Count By City ---"
            );

            foreach (var item in cityCounts)
            {
                Console.WriteLine(
                    $"{item.City} = {item.Count}"
                );
            }
        }


        // ==========================================
        // UC10 - COUNT BY STATE
        // ==========================================

        public void GetCountByState()
        {
            var allContacts = books
                .SelectMany(b => b.Contacts)
                .ToList();

            var stateCounts = allContacts
                .GroupBy(c => c.State)
                .Select(
                    g => new
                    {
                        State = g.Key,
                        Count = g.Count()
                    }
                );

            Console.WriteLine(
                "--- Contact Count By State ---"
            );

            foreach (var item in stateCounts)
            {
                Console.WriteLine(
                    $"{item.State} = {item.Count}"
                );
            }
        }
    }
}
