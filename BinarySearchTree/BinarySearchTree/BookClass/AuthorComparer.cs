using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace BookClass
{
    public class AuthorComparer : Comparer<Book>
    {
        /// <summary>
        /// Setting for compare.
        /// </summary>
        private readonly StringComparer strCmp;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorComparer"/> class.
        /// </summary>
        /// <param name="cultureInfo">Culture info.</param>
        public AuthorComparer(CultureInfo cultureInfo)
        {
            this.strCmp = StringComparer.Create(cultureInfo, false);
        }

        /// <summary>
        /// Compares objects by author.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Second object.</param>
        /// <returns>1 if <see cref="x"/> greater than <see cref="y"/>; 0 if <see cref="x"/> and <see cref="y"/> object are equal; -1 if <see cref="x"/> object less than <see cref="y"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <see cref="x"/> or <see cref="y"/> is null.</exception>
        public override int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null)
            {
                return -1;
            }

            if (y is null)
            {
                return 1;
            }

            return this.strCmp.Compare(x.Author, y.Author);
        }
    }
}

