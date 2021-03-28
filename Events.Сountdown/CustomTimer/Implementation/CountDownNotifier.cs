using System;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private readonly Timer timer;

        public CountDownNotifier(Timer timer)
        {
            this.timer = timer;
        }

        /// <inheritdoc/>
        public void Init(EventHandler<TimerEventArgs> startHandler, EventHandler<TimerEventArgs> stopHandler, EventHandler<TimerEventArgs> tickHandler)
        {
            if (!(stopHandler is null))
            {
                this.timer.Started += startHandler;
            }
            
            if (!(stopHandler is null))
            {
                this.timer.Stoped += stopHandler;
            }

            if (!(tickHandler is null))
            {
                this.timer.Tick += tickHandler;
            }
        }

        /// <inheritdoc/>
        public void Run()
        {
            this.timer.OnStarted();
        }
    }
}
