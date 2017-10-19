using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class Hash
    {
        HashSet<int> hs = new HashSet<int>();
        Timer timer = new Timer();

        public TimeSpan CheckHashAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                hs.Add(i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckHashFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            hs.Contains(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckHashDelTime(int numb)
        {

            DateTime start = DateTime.Now;
            hs.Remove(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }
    }
}
