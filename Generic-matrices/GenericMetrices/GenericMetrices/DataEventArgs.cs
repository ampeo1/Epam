using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMetrices
{
    public class DataEventArgs<T>
    {
        public DataEventArgs(T newValue)
        {
            this.NewValue = newValue;
        }

        public T NewValue { get; set; }
    }
}
