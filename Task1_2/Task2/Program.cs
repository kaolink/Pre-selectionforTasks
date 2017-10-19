using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)         
        {
            int num = 0;

            Console.WriteLine("Insert number of items in the list");

            try
            {
                num = Int32.Parse(Console.ReadLine()); // Determine number of items in the a list
            }
            catch (FormatException e)
            {
                Console.WriteLine("You have inserted incorrect data. Please find details below. \n{0}",e);
            }


            string[] list = new string[num];         // Initialization of the list


            for (int i = 0; i < num; i++)           // Population of the list
            {
                Console.WriteLine("Insert items of the list number = {0}:", i + 1);
               list[i] = Console.ReadLine();
            }

            list = GetSortedList(list);       // Sorting

            Console.WriteLine("List has been sorted by number of symbols:\n------------------------------------------");
            foreach (string str in list)  // Print sorted list
            {
                Console.WriteLine("Numder of symbols = {0}, the item = {1}",str.Length, str);
            }


            Console.WriteLine("------------------------------------------\nClick any button to exit...");
            Console.ReadKey(true);

        }



        static string [] GetSortedList(string [] list) {   // Bubble sorting of the list
            for (int j = 0; j < list.Length; j++)
            {
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (list[i].Length < list[i + 1].Length)  
                    {
                        string temp = null;
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            }
            return list;
        }
    }
}
