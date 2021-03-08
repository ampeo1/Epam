using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    /// <summary>      
    /// Provides templates for some algorithm calculating.      
    /// </summary>   
    public interface IAlgorithm
    {
        public int Calculate(int first, int second);
    }
}
