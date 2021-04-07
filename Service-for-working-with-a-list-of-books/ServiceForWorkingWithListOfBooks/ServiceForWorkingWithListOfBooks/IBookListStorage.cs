using BookClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithListOfBooks
{
    public interface IBookListStorage
    {
        public void AddBook(Book book);
        public int Count { get; }
        public Book this[int index]
        {
            get;
        }
    }
}
