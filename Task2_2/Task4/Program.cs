using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Collections;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {

            const int limit = 800000;
            const int find = 195532;


            ArrList Al = new ArrList();
            LinkList Ll = new LinkList();

            Compare(Al.CheckArrListAddTime(limit),Ll.CheckLinkListAddTime(limit),"Add","ArrayList","LinkedList");                 //LinkedList vs ArrayList
            Compare(Al.CheckArrListFindTime(find), Ll.CheckLinkListFindTime(find), "Search", "ArrayList", "LinkedList");
            Compare(Al.CheckArrListDelTime(find), Ll.CheckLinkListDelTime(find), "Remove", "ArrayList", "LinkedList");

            Que q = new Que();
            Stk stk = new Stk();

            Compare(q.CheckQAddTime(limit),stk.CheckStkAddTime(limit),"Add","Queue","Stack");           // Queue vs Stack
            Compare(q.CheckQFindTime(find), stk.CheckStkFindTime(find), "Find", "Queue", "Stack");
            Compare(q.CheckQDelTime(limit), stk.CheckStkDelTime(limit), "Remove", "Queue", "Stack");

            Hash ht = new Hash();
            Dict dict = new Dict();

            Compare(ht.CheckHashAddTime(limit), dict.CheckDictAddTime(limit), "Add", "HashTable", "Dictionary");           // HashTable vs Dictionary
            Compare(ht.CheckHashFindTime(find), dict.CheckDictFindTime(find), "Find", "HashTable", "Dictionary");
            Compare(ht.CheckHashDelTime(limit), dict.CheckDictDelTime(limit), "Remove", "HashTable", "Dictionary");

            Console.WriteLine("Thanks for using our perfomance checker. Please press any button to exit...");
            Console.ReadKey(true);
        }

        public static void Compare(TimeSpan time1, TimeSpan time2, string action, string collect1, string collect2)
        {
            if (time1 > time2)
            {
                Console.WriteLine("{0} is faster than {1} in {2} on {3}", collect2, collect1, action, time1 - time2);
            }
            else
            {
                Console.WriteLine("{0} is faster than {1} in {2} on {3}", collect1, collect2, action, time2 - time1);
            }

        }
    }
}
