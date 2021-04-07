using NUnit.Framework;
using Moq;
using ServiceForWorkingWithListOfBooks;
using BookClass;

namespace TestService
{
    class MoqTests
    {
        [Test]
        public void TestLoad()
        {
            BookListService service = new BookListService();
            service.Add(new Book("London Jack", "Eden Martin", "Mastay", "978-5-1111-0298-5"));
            service.Add(new Book("J. K. Rowling", "Harry Potter", "Scholastic", "978-0-4397-0818-0"));
            service.Add(new Book("Jack London", "Martin Eden", "Macmillan", "978-5-9925-0298-5"));
            var mock = new Mock<IBookListStorage>();
            mock.Setup(obj => obj.AddBook(It.IsAny<Book>()));

            service.Load(mock.Object);
            mock.Verify();
        }
    }
}
