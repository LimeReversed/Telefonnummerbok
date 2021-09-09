using NUnit.Framework;
using PhoneBookProject;

namespace Test_Chamber
{
    public class PhoneBook_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_OneNewEntry_NewEntryAddedCorrectly()
        {
            PhoneBook book = new PhoneBook();
            book.Add("Jane Doe", "+46761234567");
            

            Assert.IsTrue(book.sortedDic.ContainsKey("JANE DOE"));
        }

        [Test]
        public void Add_EntryIsNullOrEmpty_ThrowsArgumentException()
        {
            PhoneBook book = new PhoneBook();

            Assert.Throws<System.ArgumentException>(() => book.Add("", "+46761234567"));
            Assert.Throws<System.ArgumentException>(() => book.Add(null, "+46761234567"));
        }

        [Test]
        public void Add_NumberIsNullOrEmpty_ThrowsArgumentException()
        {
            PhoneBook book = new PhoneBook();

            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", ""));
            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", null));
        }

        [Test]
        public void Add_NumberIsInvalid_ThrowsArgumentException()
        {
            PhoneBook book = new PhoneBook();

            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", "+47767894256"));
            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", "47767894256"));
            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", "0704562315"));
            Assert.Throws<System.ArgumentException>(() => book.Add("Jane Doe", "+4678 321 45 89"));
        }

        [Test]
        public void Delete_NameNullOrEmpty_ThrowsArgumentException()
        {
            PhoneBook book = new PhoneBook();

            Assert.Throws<System.ArgumentException>(() => book.Delete(""));
            Assert.Throws<System.ArgumentException>(() => book.Delete(null));
        }

        [Test]
        public void Delete_DeletingOneEntry_DictionaryNoLongerContainsThatName()
        {
            PhoneBook book = new PhoneBook();

            Assert.IsTrue(book.sortedDic.ContainsKey("ÅSA BARSAN"));
            book.Delete("Åsa Barsan");
            Assert.IsFalse(book.sortedDic.ContainsKey("ÅSA BARSAN"));
        }

        [Test]
        public void Delete_TryingToDeleteNonExistentEntry_ThrowsArgumentOutOfRangeException()
        {
            PhoneBook book = new PhoneBook();
            Assert.Throws<System.ArgumentOutOfRangeException>(() => book.Delete("Henrik Åkerlund"));
        }
    }
}