using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Humidity : WeatherData
    {
        public override string ToString()
        {
            return $"{this.Time} Humidity: {this.Value}";
        }
    }
}
