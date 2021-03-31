using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TimeStruct;

namespace BinarySearchTree.Tests
{
    public class TimeComparer : Comparer<Time>
    {
        public override int Compare([AllowNull] Time x, [AllowNull] Time y)
        {
            if ((x.Hours * 60) + x.Minutes == (y.Hours * 60) + y.Minutes)
            {
                return 0;
            }
            else if ((x.Hours * 60) + x.Minutes > (y.Hours * 60) + y.Minutes)
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
