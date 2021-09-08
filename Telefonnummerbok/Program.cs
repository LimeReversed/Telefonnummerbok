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
            foreach (KeyValuePair<string, string> el in book.GetBook())
            {
                Console.WriteLine(el.Key + ": " + el.Value);
            }

            //ArgumentException for add
            // separate first name and last name and use an IComparable to tell it how to compare?
        }
    }

    class PhoneBook
    {
        private SortedDictionary<string, string> sortedDic = new SortedDictionary<string, string>();

        public PhoneBook()
        {
            // Creating mock data
            sortedDic.Add("Ellen Gustafsson", "0741864262");
            sortedDic.Add("Magnus Begic", "0755284319");
            sortedDic.Add("Åsa Barsan", "0757896512");
            sortedDic.Add("Kim Evasdottir", "0743547890");
            sortedDic.Add("Örjan Fin", "0744653486");
            sortedDic.Add("Robin Karlsson", "0747261272");
        }

        private bool ValidateNumber(string number)
        {
            if (number == null || number.Length < 1)
            {
                return false;
            }

            return true;
        }

        public void Add(string name, string number)
        {
            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Number is invalid");
            }

            sortedDic.Add(name, number);
        }

        public void Delete(string name)
        {
            sortedDic.Remove(name);
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
