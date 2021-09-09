using System;
using System.Collections.Generic;
using System.Globalization;

namespace Telefonnummerbok
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("se-SE", false);
            PhoneBook book = new PhoneBook();

            while (true)
            {
                Console.WriteLine(
                    "Menu " +
                    "\n" +
                    "\n1. Add " +
                    "\n2. Delete " +
                    "\n3. List Book " +
                    "\n4. Exit"
                );

                var menuChoice = Console.ReadKey();
                Console.Clear();

                if (menuChoice.KeyChar.Equals('1'))
                {
                    EnterAddMenu(book);
                }
                else if (menuChoice.KeyChar.Equals('2'))
                {
                    EnterDeleteMenu(book);
                }
                else if (menuChoice.KeyChar.Equals('3'))
                {
                    foreach (KeyValuePair<string, string> el in book.GetBook())
                    {
                        Console.WriteLine(el.Key + ": " + el.Value);
                    }
                }
                else if (menuChoice.KeyChar.Equals('4'))
                {
                    break;
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void EnterDeleteMenu(PhoneBook book)
        {
            Console.Write("Enter name of the person you want to delete: ");
            string name = Console.ReadLine();

            try
            {
                book.Delete(name);
            }
            catch (Exception e)
            {
                if (e is ArgumentException || e is ArgumentOutOfRangeException)
                {

                    Console.WriteLine("\nERROR: " + e.Message);
                }
            }
        }

        private static void EnterAddMenu(PhoneBook book)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter number: ");
            string number = Console.ReadLine();

            try
            {
                book.Add(name, number);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nERROR: " + e.Message);
            }
        }
    }

    class PhoneBook
    {
        private SortedDictionary<string, string> sortedDic = new SortedDictionary<string, string>();

        public PhoneBook()
        {
            // Creating mock data
            Add("Ellen Gustafsson", "0741864262");
            Add("Magnus Begic", "0755284319");
            Add("Åsa Barsan", "0757896512");
            Add("Kim Evasdottir", "0743547890");
            Add("Örjan Fin", "0744653486");
            Add("Robin Karlsson", "0747261272");
        }

        private bool ValidateNumber(string number)
        {

            if (number == null || number.Length < 1)
            {
                return false;
            }

            // Check that they are numbers

            return true;
        }

        public void Add(string name, string number)
        {
            if (name == null || name.Length < 1)
            {
                throw new ArgumentException("No name entered");
            }

            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Number is invalid");
            }

            sortedDic.Add(name.ToUpper(), number);
        }

        public void Delete(string name)
        {
            if (name == null || name.Length < 1)
            {
                throw new ArgumentException("No name entered");
            }

            bool result = sortedDic.Remove(name.ToUpper());

            if (!result)
            {
                throw new ArgumentOutOfRangeException("Name does not exist in the Phone book");
            }
        }

        /// <summary>
        /// Returns a copy of the Sorted Dictionary that makes up the Phone Book
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> GetBook()
        {
            foreach (var element in sortedDic)
            {
                yield return element;
            }
        }
    }
}
