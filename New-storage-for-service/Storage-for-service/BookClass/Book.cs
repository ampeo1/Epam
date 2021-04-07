using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
#pragma warning disable CA1307

namespace BookClass
{
    /// <summary>
    /// Book class.
    /// </summary>
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        private bool published = false;
        private DateTime datePublished;
        private int totalPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author name.</param>
        /// <param name="title">Book name.</param>
        /// <param name="publisher">Publisher.</param>
        public Book(string author, string title, string publisher)
        {
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author name.</param>
        /// <param name="title">Book name.</param>
        /// <param name="publisher">Publisher.</param>
        /// <param name="isbn">International Standard Book Number.</param>
        public Book(string author, string title, string publisher, string isbn) 
            : this(author, title, publisher)
        {
            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets author name.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets book name.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets publisher.
        /// </summary>
        public string Publisher { get; }

        /// <summary>
        /// Gets International Standard Book Number.
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// Gets or sets total pages.
        /// </summary>
        public int Pages
        {
            get
            {
                return this.totalPages;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)}");
                }

                this.totalPages = value;
            }
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets three-digit ISO currency symbol.
        /// </summary>
        public string Currency { get; private set; }

        /// <summary>
        /// Parse a string that contains information about the book.
        /// </summary>
        /// <param name="parseString">String that contains information about the book.</param>
        /// <exception cref="ArgumentNullException">Throws when <see cref="parseString"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Throws when string doesn't format "Title",Author,Year,Publisher,Pages,ISBN-13,Price.</exception>
        /// <returns>Book representation.</returns>
        public static Book Parse(string parseString)
        {
            if (string.IsNullOrEmpty(parseString))
            {
                throw new ArgumentNullException($"{nameof(parseString)} is null or empty", $"{nameof(parseString)}");
            }

            string[] arguments = parseString.Split(',');

            if (arguments.Length != 7)
            {
                throw new ArgumentException($"{nameof(parseString)} must has 7 arguments", $"{nameof(parseString)}");
            }

            string title = arguments[0];
            if (!title[0].Equals('"') || !title[title.Length - 1].Equals('"'))
            {
                throw new ArgumentException($"first argument must begin and end with \" ", $"{nameof(parseString)}");
            }

            Book book = new Book(arguments[1], title, arguments[3], arguments[5]);
            int year = int.Parse(arguments[2], CultureInfo.InvariantCulture);
            DateTime date = new DateTime(year, 1, 1);
            book.Publish(date);
            book.Pages = int.Parse(arguments[4], CultureInfo.InvariantCulture);
            string[] price = arguments[6].Split(' ');
            if (price.Length != 2)
            {
                throw new ArgumentException($"Can not format price currency \" ", $"{nameof(parseString)}");
            }

            book.SetPrice(decimal.Parse(price[0], CultureInfo.InvariantCulture), price[1]);

            return book;
        }

        /// <summary>
        /// Method sets <see cref="published"/> to true when it is called 
        /// and assigns the date passed to it as an argument to the private <see cref="datePublished"/> field.
        /// </summary>
        /// <param name="datePublish">Date of publication.</param>
        public void Publish(DateTime datePublish)
        {
            this.datePublished = datePublish;
            this.published = true;
        }

        /// <summary>
        /// Method returns the string "NYP" if the <see cref="published"/> is false, and the value of the <see cref="datePublished"/> field if it is true.
        /// </summary>
        /// <returns>Date of publication.</returns>
        public string GetPublicationDate()
        {
            if (this.published)
            {
                return this.datePublished.ToString("dd:MM:yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                return "NYP";
            }
        }

        /// <summary>
        /// Sets <see cref="Price"/> and <see cref="Currency"/>.
        /// </summary>
        /// <param name="price">Book price.</param>
        /// <param name="currency">Is the three-digit ISO currency symbol.</param>
        public void SetPrice(decimal price, string currency)
        {
            this.Price = price;
            this.Currency = currency;
        }

        /// <summary>
        /// Gets string representation object.
        /// </summary>
        /// <returns>String representation object.</returns>
        public override string ToString()
        {
            return $"{this.Title} by {this.Author}";
        }

        /// <summary>
        /// Returns the hash code for this book.
        /// </summary>
        /// <returns>A 32-bit signed integer hash-code</returns>
        public override int GetHashCode()
        {
            if (this.ISBN is null)
            {
                return 0;
            }

            return this.ISBN.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">Specified object.</param>
        /// <returns>True if are equal; otherwise false.</returns>
        public override bool Equals(object obj) => obj is Book && this.Equals((Book)obj);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">Specified object.</param>
        /// <returns>True if are equal; otherwise false.</returns>
        public bool Equals([AllowNull] Book other)
        {
            if (other == null || this.GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            if (this.ISBN is null && other.ISBN is null)
            {
                return true;
            }

            return this.ISBN.Equals(other.ISBN, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares objects.
        /// </summary>
        /// <param name="other">The object to compare with.</param>
        /// <returns>1 if this object greater than other; 0 if this and other object are equal; -1 if this object less than other.</returns>
        public int CompareTo([AllowNull] Book other)
        {
            if (other is null)
            {
                return -1;
            }

            if (this.Title is null && other.Title is null)
            {
                return 0;
            }

            if (this.Title is null)
            {
                return -1;
            }

            return this.Title.CompareTo(other.Title);
        }

        /// <summary>
        /// Compares objects.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>1 if this object greater than other; 0 if this and other object are equal; -1 if this object less than other.</returns>
        /// <exception cref="ArgumentException">Throw when <see cref="obj"/> not Book class.</exception>
        public int CompareTo(object obj) => obj is Book ? this.CompareTo((Book)obj) : throw new ArgumentException($"{nameof(obj)}");

        public string ParseToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\"");
            builder.Append(this.Title);
            builder.Append("\",");
            builder.Append(this.Author);
            builder.Append(",");
            builder.Append(this.datePublished.Year);
            builder.Append(",");
            builder.Append(this.Publisher);
            builder.Append(",");
            builder.Append(this.Pages);
            builder.Append(",");
            builder.Append(this.ISBN);
            builder.Append(",");
            builder.Append(this.Price);
            builder.Append(" ");
            builder.Append(this.Currency);

            return builder.ToString();
        }
    }
}
