using BookClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithListOfBooks
{
    public interface IBookListStorage
    {
        public List<Book> Load();
        public void Save(List<Book> books);
    }
}
