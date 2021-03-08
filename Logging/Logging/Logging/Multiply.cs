using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    class Multiply : IAlgorithm
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
}
