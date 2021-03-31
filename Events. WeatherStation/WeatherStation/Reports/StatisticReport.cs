using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class StatisticReport : IReport
    {
        List<WeatherData> weatherData = new List<WeatherData>();
        public void AcceptData(object sender, WeatherData data)
        {
            weatherData.Add(data);
        }

        public void Display()
        {
            foreach (var item in weatherData)
            {
                Console.WriteLine(item);
            }
        }
    }
}
