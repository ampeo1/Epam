using System;
using System.Collections.Generic;
using System.Text;

namespace Flavius_Josephus_Task
{
    public static class Flavius
    {
        public static IEnumerable<int> Josephus(int n, int k)
        {
            if (n < 1 || k < 0)
            {
                throw new ArgumentException($"{nameof(n)}, {nameof(k)}");
            }

            return Algorithm(n, k);
        }

        private static IEnumerable<int> Algorithm(int n, int k)
        {
            List<int> numeration = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                numeration.Add(i);
            }

            int index = 0;
            k--;
            while (numeration.Count != 1)
            {
                index = (index + k) % numeration.Count;
                yield return numeration[index];
                numeration.RemoveAt(index);
            }
        }

    }
}
