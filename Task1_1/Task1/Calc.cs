using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1
{
    class Calc
    {
        public static void Main(string[] args)
        {
            int act = 0;
            int fNumb = 0;
            int sNumb = 0;

            Console.WriteLine("Calculator v 1.0.0.1\n--------------------\nInsert FIRST number\n--------------------");
            fNumb = GetNumber();
            Console.WriteLine("SELECT the ACTION\n------------------------------------------------------------------");
            Console.WriteLine("1 - Sum, 2 - Division, 3 - Multiplication, 4 - Subtraction\n------------------------------------------------------------------");

            try
            {
                act = GetNumber();

                if (act >= 5 || act < 1)
                {
                    throw new IndexOutOfRangeException("There is no such ACTION");
                }
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Insert SECOND number\n--------------------");
            sNumb = GetNumber();

            switch (act)
            { 
                case 1: 
                    Console.WriteLine("{0} + {1} = {2}", fNumb, sNumb, Sum(fNumb, sNumb));
                    break;
                case 2:
                    Console.WriteLine("{0} / {1} = {2}", fNumb, sNumb, Div(fNumb, sNumb));
                    break;
                case 3:
                    Console.WriteLine("{0} * {1} = {2}", fNumb, sNumb, Mult(fNumb, sNumb));
                    break;
                case 4:
                    Console.WriteLine("{0} - {1} = {2}", fNumb, sNumb, Sub(fNumb, sNumb));
                    break;

            }

            Console.WriteLine("\nPress \" ENTER \" to exit ");
            Console.ReadKey(true);
        }

        public static double Sum(double a, double b)
        {
            return a + b;
        }

        private static double Sub (double a, double b)
        {
            return a - b;
        }

        private static double Mult(double a, double b)
        {
            return a * b;
        }

        private static double Div(double a, double b)
        {
            return (double)(a / b);
        }

        private static int GetNumber()
        {
            int numb = 0;

            try
            {
                 numb = Int32.Parse(Console.ReadLine()); // Read number from console
            }
            catch (FormatException e)
            {
                Console.WriteLine("Incorrect Symbol. Error message = {0}", e);
            }

            Console.WriteLine("--------------------");
            return numb;
        }
    }
}
