using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    class Sum : IAlgorithm
    {
        public int Calculate(int first, int second)
        {
            return first + second;
        }
    }
}
