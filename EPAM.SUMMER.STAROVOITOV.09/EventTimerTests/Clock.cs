using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventTimer;
using static System.Console;

namespace EventTimerTests
{
    sealed class Clock
    {
        public Clock(Timer timer)
        {
            timer.TimeOver += ShowMessage;
        }

        private void ShowMessage(object sender, TimeOverEventArgs e)
        {
            WriteLine(nameof(Clock) + " message");
            WriteLine($"{e.Time} seconds is over.");
        }

        public void Unregister(Timer timer)
        {
            timer.TimeOver -= ShowMessage;
        }

        public void Register(Timer timer)
        {
            timer.TimeOver += ShowMessage;
        }
    }
}
