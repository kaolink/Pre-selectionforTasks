using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class ArrList
    {
       static ArrayList Al = new ArrayList();
       Timer timer = new Timer();

       public ArrList()
       {
       }

        public TimeSpan CheckArrListAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                Al.Add(i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckArrListFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            Al.IndexOf(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckArrListDelTime(int numb)
        {

            DateTime start = DateTime.Now;
            Al.Remove(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }


    }



}
