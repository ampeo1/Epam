using System;

namespace Data
{
    public abstract class WeatherData
    {
        private int val;
        public int Value 
        {
            get
            {
                return val;
            }
            set
            {
                this.val = value;
                this.Time = DateTime.Now;
                ValueChanged.Invoke(this, this);
            }
        }

        public DateTime Time { get; private set; }

        public abstract override string ToString();

        public static event Action<object, WeatherData> ValueChanged;
    }
}
