using Data;
using System;

namespace Reports
{
    public interface IReport
    {
        public void AcceptData(object sender, WeatherData data);
        public void Display();
    }
}
