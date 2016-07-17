using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventTimer;
using static System.Console;

namespace EventTimerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            var microwave = new Microwave(timer);
            var clock = new Clock(timer);

            timer.Time = 5;
            timer.Start();
            WriteLine();

            clock.Unregister(timer);
            timer.Start();
            WriteLine();

            timer.Time = 2;
            timer.Start();
            WriteLine();

            microwave.Unregister(timer);
            clock.Register(timer);
            timer.Start();
            Read();
        }
    }
}
