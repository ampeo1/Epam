using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Temperature : WeatherData
    {
        public override string ToString()
        {
            return $"{this.Time} Temperature: {this.Value}";
        }
    }
}
