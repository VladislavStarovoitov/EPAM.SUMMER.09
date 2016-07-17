using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventTimer;
using static System.Console;

namespace EventTimer.Tests
{
    sealed class Microwave
    {
        public Microwave(Timer timer)
        {
            timer.TimeOver += ShowMessage;
        }

        private void ShowMessage(object sender, TimeOverEventArgs e)
        {
            WriteLine(nameof(Microwave) + " message");
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
