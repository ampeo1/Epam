using BookClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TimeStruct;

namespace BinarySearchTree.Tests
{
    public sealed class DataSource
    {
        public static IEnumerable<TestCaseData> TestCasesString
        {
            get
            {
                yield return new TestCaseData(new string[] { "12", "Zero", "Test", "Hello" }, new[] { "12", "Zero", "Test", "Hello" },
                    new[] { "12", "Hello", "Test", "Zero" }, new[] { "Hello", "Test", "Zero", "12" }, null);
                yield return new TestCaseData(new string[] { "12", "Zero", "Test", "Hello" }, new[] { "12", "Zero", "Test", "Hello" },
                    new[] { "12", "Hello", "Test", "Zero" }, new[] { "Hello", "Test", "Zero", "12" }, new StringComparer());
            }
        }

        public static IEnumerable<TestCaseData> TestCasesInt32
        {
            get
            {
                yield return new TestCaseData(new int[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 1, 3, 4, 6, 7, 8, 10, 14 },
                    new[] { 1, 4, 7, 6, 3, 14, 10, 8 }, null);
                yield return new TestCaseData(new int[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 1, 3, 4, 6, 7, 8, 10, 14 },
                    new[] { 1, 4, 7, 6, 3, 14, 10, 8 }, new IntComparer());
            }
        }

        public static IEnumerable<TestCaseData> TestCasesBookWithoutComparer
        {
            get
            {
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg")
                    },
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg")
                    },
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg")
                    },
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book(null, "19asfas84", "Secker and Warburg"),
                        new Book("Oleg", "198asf4", "Secker and Warburg"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg")
                    });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesBookWithComparer
        {
            get
            {
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg", "1"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg", "2"),
                        new Book(null, "19asfas84", "Secker and Warburg", "3"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "4"),
                        new Book(null, "19asfas84", "Secker and Warburg", "5"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "6"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg", "7")
                    },
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg", "1"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg", "2"),
                        new Book(null, "19asfas84", "Secker and Warburg", "3"),
                        new Book(null, "19asfas84", "Secker and Warburg", "5"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "4"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "6"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg", "7")
                    },
                    new Book[]
                    {
                        new Book(null, "19asfas84", "Secker and Warburg", "3"),
                        new Book(null, "19asfas84", "Secker and Warburg", "5"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg", "2"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "4"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "6"),
                        new Book("Yagovdic", "1safas984", "Secker and Warburg", "7"),
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg", "1"),
                    },
                    new Book[]
                    {
                        new Book(null, "19asfas84", "Secker and Warburg", "5"),
                        new Book(null, "19asfas84", "Secker and Warburg", "3"),
                        new Book("Sidorenko", "1safas984", "Secker and Warburg", "7"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "6"),
                        new Book("Oleg", "198asf4", "Secker and Warburg", "4"),
                        new Book("ABCDEFG", "fas1984", "Secker and Warburg", "2"),
                        new Book("Джорджа Оруэлла", "19das84", "Secker and Warburg", "1"),
                    },
                    new AuthorComparer(CultureInfo.CurrentCulture));
            }
        }
        public static IEnumerable<TestCaseData> TestCasesTimeStruct
        {
            get
            {
                yield return new TestCaseData(
                    new Time[]
                    {
                        new Time(32, 3124),
                        new Time(15120, 123),
                        new Time(-10, 3),
                        new Time(10, -3),
                        new Time(140, -5123)
                    },
                    new Time[]
                    {
                        new Time(32, 3124),
                        new Time(15120, 123),
                        new Time(10, -3),
                        new Time(140, -5123),
                        new Time(-10, 3)
                    },
                    new Time[]
                    {
                        new Time(15120, 123),
                        new Time(140, -5123),
                        new Time(10, -3),
                        new Time(32, 3124),
                        new Time(-10, 3)
                    },
                    new Time[]
                    {
                        new Time(140, -5123),
                        new Time(10, -3),
                        new Time(15120, 123),
                        new Time(-10, 3),
                        new Time(32, 3124)
                    },
                new TimeComparer());
            }
        }
    }
}
