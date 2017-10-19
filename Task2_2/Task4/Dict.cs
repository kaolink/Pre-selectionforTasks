using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class Dict
    {
        Timer timer = new Timer();
        Dictionary<int, int> dict = new Dictionary<int, int>();

        public TimeSpan CheckDictAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                dict.Add(i,i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckDictFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            dict.ContainsValue(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckDictDelTime(int numb)
        {

            DateTime start = DateTime.Now;
            dict.Remove(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }
    }
}
