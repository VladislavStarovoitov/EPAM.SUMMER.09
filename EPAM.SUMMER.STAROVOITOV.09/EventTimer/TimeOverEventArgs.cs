﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTimer
{
    /// <summary>
    /// Provides data for the TimeOver event.
    /// </summary>
    public sealed class TimeOverEventArgs: EventArgs
    {
        private int _time;

        public TimeOverEventArgs(int time)
        {
            _time = time;
        }

        public int Time => _time;
    }
}
