using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class Que
    {
        Queue queue = new Queue();
        Timer timer = new Timer();

        public TimeSpan CheckQAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                queue.Enqueue(i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckQFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            queue.Contains(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckQDelTime(int numb)
        {

            DateTime start = DateTime.Now;
             for (int i = 0; i < numb; i++)
            {
                queue.Dequeue();
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }
    }
}
