using System;
using System.Collections.Generic;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;

public class Program
{
    public static void Main()
    {
        AddressBook addressBook = new AddressBook();

        AddressBookMain addressBookMain =
            new AddressBookMain();

        // Add AddressBook into AddressBookMain
        addressBookMain.AddAddressBook(addressBook);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("-------- Address Book Menu -------");

            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Show All Contacts");
            Console.WriteLine("5. Total Contact Count");
            Console.WriteLine("6. Search by City");
            Console.WriteLine("7. Search by State");
            Console.WriteLine("8. View by City / State");
            Console.WriteLine("9. Count by City / State");
            Console.WriteLine("10. Sort by Name");
            Console.WriteLine("11. Sort by City / State / Zip");
            Console.WriteLine("12. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddContact(addressBook);
                        break;

                    case "2":
                        EditContact(addressBook);
                        break;

                    case "3":
                        DeleteContact(addressBook);
                        break;

                    case "4":
                        addressBook.PrintAll();
                        break;

                    case "5":
                        int total =
                            addressBookMain.GetTotalContactCount();

                        Console.WriteLine(
                            $"Total contacts: {total}"
                        );
                        break;

                    case "6":
                        SearchByCity(addressBookMain);
                        break;

                    case "7":
                        SearchByState(addressBookMain);
                        break;

                    case "8":
                        ViewByCityOrState(addressBookMain);
                        break;

                    case "9":
                        CountByCityOrState(addressBookMain);
                        break;

                    case "10":
                        Console.WriteLine();
                        Console.WriteLine("--- Contacts Sorted By Name ---");

                        addressBook.SortByName();
                        break;

                    case "11":
                        SortByCityStateZip(addressBook);
                        break;

                    case "12":
                        Console.WriteLine(
                            "Exiting Address Book..."
                        );
                        return;

                    default:
                        Console.WriteLine(
                            "Invalid choice. Please try again."
                        );
                        break;
                }
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine(
                    "Error: " + ex.Message
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Unexpected Error: " + ex.Message
                );
            }
        }
    }


    // ==========================================
    // UC3 - ADD CONTACT
    // ==========================================

    static void AddContact(
        AddressBook addressBook)
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter address: ");
        string address = Console.ReadLine();

        Console.Write("Enter city: ");
        string city = Console.ReadLine();

        Console.Write("Enter state: ");
        string state = Console.ReadLine();

        Console.Write("Enter zip: ");
        string zip = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Contact contact = new Contact(
            firstName,
            lastName,
            address,
            city,
            state,
            zip,
            phoneNumber,
            email
        );

        addressBook.AddContact(contact);
    }


    // ==========================================
    // UC4 - EDIT CONTACT
    // ==========================================

    static void EditContact(
        AddressBook addressBook)
    {
        Console.Write("Enter first name to edit: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name to edit: ");
        string lastName = Console.ReadLine();

        addressBook.EditContact(
            firstName,
            lastName
        );
    }


    // ==========================================
    // UC5 - DELETE CONTACT
    // ==========================================

    static void DeleteContact(
        AddressBook addressBook)
    {
        Console.Write("Enter first name to delete: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name to delete: ");
        string lastName = Console.ReadLine();

        addressBook.DeleteContact(
            firstName,
            lastName
        );
    }


    // ==========================================
    // UC8 - SEARCH BY CITY
    // ==========================================

    static void SearchByCity(
        AddressBookMain addressBookMain)
    {
        Console.Write("Enter city to search: ");
        string city = Console.ReadLine();

        List<Contact> contacts =
            addressBookMain.SearchByCity(city);

        if (contacts.Count == 0)
        {
            Console.WriteLine(
                "No contacts found."
            );

            return;
        }

        Console.WriteLine(
            $"Found {contacts.Count} contact(s):"
        );

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }


    // ==========================================
    // UC8 - SEARCH BY STATE
    // ==========================================

    static void SearchByState(
        AddressBookMain addressBookMain)
    {
        Console.Write("Enter state to search: ");
        string state = Console.ReadLine();

        List<Contact> contacts =
            addressBookMain.SearchByState(state);

        if (contacts.Count == 0)
        {
            Console.WriteLine(
                "No contacts found."
            );

            return;
        }

        Console.WriteLine(
            $"Found {contacts.Count} contact(s):"
        );

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }


    // ==========================================
    // UC9 - VIEW BY CITY / STATE
    // ==========================================

    static void ViewByCityOrState(
        AddressBookMain addressBookMain)
    {
        Console.WriteLine();
        Console.WriteLine("1. View by City");
        Console.WriteLine("2. View by State");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            addressBookMain.ViewByCity();
        }
        else if (choice == "2")
        {
            addressBookMain.ViewByState();
        }
        else
        {
            Console.WriteLine(
                "Invalid choice."
            );
        }
    }


    // ==========================================
    // UC10 - COUNT BY CITY / STATE
    // ==========================================

    static void CountByCityOrState(
        AddressBookMain addressBookMain)
    {
        Console.WriteLine();
        Console.WriteLine("1. Count by City");
        Console.WriteLine("2. Count by State");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            addressBookMain.GetCountByCity();
        }
        else if (choice == "2")
        {
            addressBookMain.GetCountByState();
        }
        else
        {
            Console.WriteLine(
                "Invalid choice."
            );
        }
    }


    // ==========================================
    // UC12 - SORT BY CITY / STATE / ZIP
    // ==========================================

    static void SortByCityStateZip(
        AddressBook addressBook)
    {
        Console.WriteLine();
        Console.WriteLine("1. Sort by City");
        Console.WriteLine("2. Sort by State");
        Console.WriteLine("3. Sort by Zip");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":

                Console.WriteLine(
                    "--- Contacts Sorted By City ---"
                );

                addressBook.SortByCity();
                break;


            case "2":

                Console.WriteLine(
                    "--- Contacts Sorted By State ---"
                );

                addressBook.SortByState();
                break;


            case "3":

                Console.WriteLine(
                    "--- Contacts Sorted By Zip ---"
                );

                addressBook.SortByZip();
                break;


            default:

                Console.WriteLine(
                    "Invalid choice."
                );

                break;
        }
    }
}

