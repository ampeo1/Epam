using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class SubscriberWeatherData
    {
        public static void Subscribe(IReport report)
        {
            WeatherData.ValueChanged += report.AcceptData;
        }
    }
}
