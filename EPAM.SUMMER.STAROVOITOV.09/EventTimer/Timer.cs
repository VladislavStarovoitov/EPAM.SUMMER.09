using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventTimer
{
    public sealed class Timer
    {
        private int _time;

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
