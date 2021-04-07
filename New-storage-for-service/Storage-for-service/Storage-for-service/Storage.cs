using BookClass;
using ServiceForWorkingWithListOfBooks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storage_for_service
{
    public class Storage : IBookListStorage
    {
        public List<Book> Load()
        {
            string path = "load.bin";
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while(reader.PeekChar() > -1)
                {
                    books.Add(Book.Parse(reader.ReadString()));
                }
            }

            return books;
        }

        public void Save(List<Book> books)
        {
            string path = "save.bin";
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.ParseToString());
                }
            }
        }
    }
}
