using System;

namespace BinarySearch
{
    public class Algorithms<T>
    {
        /// <summary>
        /// This method implements algorithm binary search.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="item">The item wich we need find.</param>
        /// <returns>Index element wich we need find.</returns>
        /// <exception cref="ArgumentNullException">Throws when <see cref="array"/> or <see cref="item"/> is null.</exception>
        public int? BinarySearch(T[] array, T item)
        {
            if (array is null || item is null)
            {
                throw new ArgumentNullException($"{nameof(array)}, {nameof(array)}");
            }

            if (array.Length == 0)
            {
                return null;
            }

            if (item is IComparable)
            {
                return this.Search(array, item as IComparable, 0, array.Length);
            }
            else
            {
                return null;
            }
        }

        private int? Search(T[] array, IComparable item, int leftRange, int rightRange)
        {
            if (leftRange > rightRange)
            {
                return null;
            }

            int mid = (leftRange + rightRange) / 2;
            int resultCompare = item.CompareTo(array[mid]);
            if (resultCompare == 0)
            {
                return (int?)mid;
            }

            if (resultCompare == 1)
            {
                return this.Search(array, item, mid + 1, rightRange);
            }
            else
            {
                return this.Search(array, item, leftRange, mid);
            }
        }
    }
}
