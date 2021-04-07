using BookClass;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ServiceForWorkingWithListOfBooks
{
    public class BookListService
    {
        private List<Book> books = new List<Book>();

        public void Add(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)}");
            }

            books.Add(book);
        }

        public void Remove(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)}");
            }

            if (!books.Remove(book))
            {
                throw new ArgumentException($"{nameof(book)} isn't found", $"{nameof(book)}");
            }
        }

        public IReadOnlyCollection<Book> FindByTag<T>(T key, string tag)
        {
            PropertyInfo property = typeof(Book).GetProperty(tag);
            if (property is null)
            {
                throw new ArgumentNullException($"{nameof(tag)} is'n found", $"{nameof(tag)}");
            }

            if (!key.GetType().Equals(property.PropertyType))
            {
                throw new ArgumentException("The types do not match", $"{nameof(key)}");  
            }

            List<Book> result = new List<Book>();
            foreach(Book item in books)
            {
                if (property.GetValue(item).Equals(key))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void SortBy(string tag)
        {
            PropertyInfo property = typeof(Book).GetProperty(tag);
            if (property is null)
            {
                throw new ArgumentNullException($"{nameof(tag)} is'n found", $"{nameof(tag)}");
            }

            IComparer<dynamic> comparer = Comparer<dynamic>.Default;
            if (comparer is null)
            {
                throw new ArgumentException($"{nameof(comparer)}");
            }

            for (int i = 1; i < books.Count; i++)
            {
                int itemIndex = i;
                for (int j = i - 1; j != -1; j--)
                {
                    if (comparer.Compare(property.GetValue(books[itemIndex]), property.GetValue(books[j])) == -1)
                    {
                        (books[itemIndex], books[j]) = (books[j], books[itemIndex]);
                        itemIndex--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void Load(IBookListStorage storage)
        {
            for(int i = 0; i < storage.Count; i++)
            {
                books.Add(storage[i]);
            }
        }

        public void Save(IBookListStorage storage)
        {
            foreach(Book book in books)
            {
                storage.AddBook(book);
            }
        }

        public IReadOnlyCollection<Book> GetBooks()
        {
            return books;
        }
    }
}
