using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class CurrentConditionsReport : IReport
    {
        WeatherData data;
        public void AcceptData(object sender, WeatherData data)
        {
            this.data = data;
            Display();
        }

        public void Display()
        {
            Console.WriteLine(data);
        }

        public void SendReport(object sender, WeatherData data)
        {
            Console.WriteLine($"{DateTime.Now}: {data}");
        }
    }
}
