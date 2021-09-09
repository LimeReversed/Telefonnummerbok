using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Test_Chamber")]

namespace PhoneBookProject
{
    public class PhoneBook
    {
        internal SortedDictionary<string, string> sortedDic = new SortedDictionary<string, string>();

        public PhoneBook()
        {
            // Creating mock data
            Add("Ellen Gustafsson", "+46741864262");
            Add("Magnus Begic", "+46755284319");
            Add("Åsa Barsan", "+46757896512");
            Add("Kim Evasdottir", "+46743547890");
            Add("Örjan Fin", "+46744653486");
            Add("Robin Karlsson", "+46747261272");
        }

        private bool ValidateNumber(string number)
        {

            if (number == null || number.Length < 1)
            {
                return false;
            }

            Regex regex = new Regex("(\\+467)[0-9]{8}");

            if (!regex.IsMatch(number))
            {
                return false;
            }

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
                throw new ArgumentException("Number is the wrong format");
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
