using BookClass;
using ServiceForWorkingWithListOfBooks;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestService
{
    class FakeBookListStorage : IBookListStorage
    {
        public List<Book> books = new List<Book>();
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)}", "Index is not a valid.");
                }

                return books[index];
            }
        }

        public int Count
        {
            get
            {
                return books.Count;
            }
        }

        public void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)}");
            }

            books.Add(book);
        }
    }
}
