using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateAndLambdas
{
    internal class Timer
    {
        private int interval;

        public delegate void TimerTickHandler(object sender, EventArgs args);

        public event TimerTickHandler TimerTicked;

        public Timer(int interval)
        {
            this.interval = interval;
        }

        public void Star()
        {
            while (true)
            {
                Thread.Sleep(interval);
                OnTimerTicked();
            }
        }

        protected virtual void OnTimerTicked()
        {
            if (TimerTicked != null)
            {
                TimerTicked(this, EventArgs.Empty);
            }
        }
    }
}
