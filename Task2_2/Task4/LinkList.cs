using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class LinkList
    {
        static LinkedList<int> Ll = new LinkedList<int>();
        Timer timer = new Timer();

       public LinkList()
       {
       }

        public TimeSpan CheckLinkListAddTime(int numb)
        {

            DateTime start = DateTime.Now;
            for (int i = 0; i < numb; i++)
            {
                Ll.AddLast(i);
            }
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckLinkListFindTime(int numb)
        {

            DateTime start = DateTime.Now;
            Ll.Find(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

        public TimeSpan CheckLinkListDelTime(int numb)
        {

            DateTime start = DateTime.Now;
            Ll.Remove(numb);
            DateTime end = DateTime.Now;
            return timer.GetTime(start, end);
        }

    }
}
