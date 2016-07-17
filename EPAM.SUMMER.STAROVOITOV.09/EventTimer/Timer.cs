using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventTimer
{
    /// <summary>
    /// Provides an event for executing methods at specified intervals.This class cannot be inherited.
    /// </summary>
    public sealed class Timer
    {
        private int _time;

        /// <summary>
        /// Occurs when time is over.
        /// </summary>
        public event EventHandler<TimeOverEventArgs> TimeOver = delegate { };
        public int Time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value >= 0)
                    _time = value;
                else
                    new ArgumentOutOfRangeException(nameof(Time));
            }
        }

        /// <summary>
        /// Starts the countdown.
        /// </summary>
        public void Start()
        {
            Thread.Sleep(_time * 1000);
            OnTimeOver(new TimeOverEventArgs(Time));
        }

        private void OnTimeOver(TimeOverEventArgs e)
        {
            TimeOver(this, e);
        }
    }
}
