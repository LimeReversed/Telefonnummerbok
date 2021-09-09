using System;
using System.Collections.Generic;
using System.Globalization;
using PhoneBookProject;

namespace ConsoleApp_Telefonnummerbok
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

            Console.Write("Enter number (+467XXXXXXXX): ");
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
}
