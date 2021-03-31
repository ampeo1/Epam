using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTree.Tests
{
    public class IntComparer : Comparer<int>
    {
        public override int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x == y)
            {
                return 0;
            }
            else if (x > y)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
