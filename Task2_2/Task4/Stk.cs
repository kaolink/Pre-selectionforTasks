using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class Stk
    {
        Stack stack = new Stack();
        Timer timer = new Timer();

        public TimeSpan CheckStkAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                stack.Push(i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckStkFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            stack.Contains(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckStkDelTime(int numb)
        {

            DateTime start = DateTime.Now;
            for(int i = 0 ; i < numb ; i++)
            {
                stack.Peek();
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }
    }
}
