using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTimer
{
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string name, int ticks)
        {
            this.Name = name;
            this.Ticks = ticks;
        }

        public string Name { get; set; }

        public int Ticks { get; set; }
    }
}
