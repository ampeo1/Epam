using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTree.Tests
{
    public class StringComparer : Comparer<string>
    {
        public override int Compare([AllowNull] string x, [AllowNull] string y)
        {
            if (x is null && y is null)
            {
                return 0;
            }
            else if (x is null)
            {
                return -1;
            }
            else if (y is null)
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }
}
