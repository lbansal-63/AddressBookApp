using System;
using System.Collections.Generic;
using System.Text;
using AddressBookApp.Models;
using System.Text.RegularExpressions;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        public static void Validate(Contact c)
        {
            if (!IsValidName(c.FirstName))
            {
                throw new InvalidContactException(
                    "First name starts with capital letter and contains atleast 3 characters."
                );
            }

            if (!IsValidName(c.LastName))
            {
                throw new InvalidContactException(
                    "Last name starts with capital letter and contains atleast 3 characters."
                );
            }

            if (!IsValidAddress(c.Address))
            {
                throw new InvalidContactException(
                    "Address must contains atleast 4 characters."
                );
            }

            if (!IsValidAddress(c.City))
            {
                throw new InvalidContactException(
                    "City must contains atleast 4 characters."
                );
            }

            if (!IsValidAddress(c.State))
            {
                throw new InvalidContactException(
                    "State must contains atleast 4 characters."
                );
            }

            if (!IsValidZip(c.Zip))
            {
                throw new InvalidContactException(
                    "Zip must contains exactly 6 digits."
                );
            }

            if (!IsValidPhone(c.PhoneNum))
            {
                throw new InvalidContactException(
                    "Phone Number must contains exactly 10 digits."
                );
            }

            if (!IsValidEmail(c.Email))
            {
                throw new InvalidContactException(
                    "Invalid Email"
                );
            }
        }

        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, "^[A-Z][a-zA-Z]{3,}$");
        }
        public static bool IsValidAddress(string value)
        {
            return Regex.IsMatch(value, "^.{4,}$");
        }
        public static bool IsValidZip(string zip)
        {
            return Regex.IsMatch(zip, "^[0-9]{6}$");
        }
        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, "^[0-9]{10}$");
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(
                email,
                "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"
            );
        }
    }
}