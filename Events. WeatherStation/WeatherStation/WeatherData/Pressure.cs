using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Pressure : WeatherData
    {
        public override string ToString()
        {
            return $"{this.Time} Pressure: {this.Value}";
        }
    }
}
