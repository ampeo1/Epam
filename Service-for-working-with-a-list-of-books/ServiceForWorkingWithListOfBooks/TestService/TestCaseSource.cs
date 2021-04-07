using BookClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestService
{
    class TestCaseSource
    {
        public static IEnumerable<TestCaseData> TestCaseBookForAdd
        {
            get
            {
                yield return new TestCaseData(new Book("Jack London", "Martin Eden", "Macmillan", "978-5-9925-0298-5"), 1);
                yield return new TestCaseData(new Book("London Jack", "Eden Martin", "Mastay", "978-5-1111-0298-5"), 2);
                yield return new TestCaseData(new Book("J. K. Rowling", "Harry Potter", "Scholastic", "978-0-4397-0818-0"), 3);
                yield return new TestCaseData(new Book("London Jack", "Eden Martin", "Mastay", "978-5-9925-2222-5"), 4);
            }
        }

        public static IEnumerable<TestCaseData> TestCaseBookForRemove
        {
            get
            {
                yield return new TestCaseData(new Book("London Jack", "Eden Martin", "Mastay", "978-5-9925-2222-5"), 3);
            }
        }

        public static IEnumerable<TestCaseData> TestCaseBookForFind
        {
            get
            {
                yield return new TestCaseData(new Book[] { new Book("Jack London", "Martin Eden", "Macmillan", "978-5-9925-0298-5") }, "Jack London", "Author");
                yield return new TestCaseData(new Book[] { new Book("London Jack", "Eden Martin", "Mastay", "978-5-1111-0298-5") }, "Eden Martin", "Title");
                yield return new TestCaseData(new Book[] { new Book("J. K. Rowling", "Harry Potter", "Scholastic", "978-0-4397-0818-0") }, "Scholastic", "Publisher");
                yield return new TestCaseData(new Book[] { }, "978-5-9925-2222-5", "ISBN");
            }
        }

        public static IEnumerable<TestCaseData> TestCaseBookForSort
        {
            get
            {
                yield return new TestCaseData("Title", new Book[]
                {
                    new Book("London Jack", "Eden Martin", "Mastay", "978-5-1111-0298-5"),
                    new Book("J. K. Rowling", "Harry Potter", "Scholastic", "978-0-4397-0818-0"),
                    new Book("Jack London", "Martin Eden", "Macmillan", "978-5-9925-0298-5"),
                });
            }
        }
    }
}
