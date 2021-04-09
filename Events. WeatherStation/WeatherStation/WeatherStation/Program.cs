using Data;
using Reports;
using System;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            StatisticReport statisticReport = new StatisticReport();
            CurrentConditionsReport conditionsReport = new CurrentConditionsReport();
            SubscriberWeatherData.Subscribe(statisticReport);
            SubscriberWeatherData.Subscribe(conditionsReport);
            Pressure pressure = new Pressure();
            pressure.Value = 1000;
            Humidity humidity = new Humidity();
            humidity.Value = 100;
            Temperature temperature = new Temperature();
            temperature.Value = 25;

            statisticReport.Display();
        }
    }
}
