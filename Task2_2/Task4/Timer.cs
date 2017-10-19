using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class Timer
    {
        public Timer()
        {
        }

        public TimeSpan GetTime(DateTime start, DateTime end)
        {
            return end - start;
        }
    }
}
