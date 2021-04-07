using BookClass;
using NUnit.Framework;
using ServiceForWorkingWithListOfBooks;

namespace TestService
{
    public class TestsBookListService
    {
        public BookListService service = new BookListService();

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseBookForAdd))]
        [Order(0)]
        public void TestAdd(Book book, int count)
        {
            service.Add(book);
            Assert.AreEqual(count, service.GetBooks().Count);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseBookForRemove))]
        [Order(1)]
        public void TestRemove(Book book, int count)
        {
            service.Remove(book);
            Assert.AreEqual(count, service.GetBooks().Count);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseBookForFind))]
        [Order(2)]
        public void TestFind(Book[] expected, string key, string tag)
        {
            var actual =  service.FindByTag(key, tag);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseBookForSort))]
        [Order(3)]
        public void TestFind(string tag, Book[] expected)
        {
            service.SortBy(tag);
            CollectionAssert.AreEqual(expected, service.GetBooks());
        }
    }
}