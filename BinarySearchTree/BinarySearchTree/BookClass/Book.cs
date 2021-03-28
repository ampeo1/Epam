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
        public string Author
        {
            get;
        }

        /// <summary>
        /// Gets book name.
        /// </summary>
        public string Title
        {
            get;
        }

        /// <summary>
        /// Gets publisher.
        /// </summary>
        public string Publisher
        {
            get;
        }

        /// <summary>
        /// Gets International Standard Book Number.
        /// </summary>
        public string ISBN
        {
            get;
        }

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
        public decimal Price
        {
            get; private set;
        }

        /// <summary>
        /// Gets three-digit ISO currency symbol.
        /// </summary>
        public string Currency
        {
            get; private set;
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
    }
}

