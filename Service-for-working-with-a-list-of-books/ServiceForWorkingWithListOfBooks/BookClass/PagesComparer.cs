using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BookClass
{
    public class PagesComparer : Comparer<Book>
    {
        /// <summary>
        /// Compares objects by page.
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

            if (y is null || x.Pages > y.Pages)
            {
                return 1;
            }

            if (x.Pages == y.Pages)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
