using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int lowBord = 0;
            int highBord = 0;

            VacuumCleaner vc1 = new VacuumCleaner(100, "PHILIPS");    // Apps initialization
            VacuumCleaner vc2 = new VacuumCleaner(150, "LG");
            VacuumCleaner vc3 = new VacuumCleaner(80, "HORIZONT");
            Iron i1 = new Iron(50, "VITEC");
            Iron i2 = new Iron(95, "SAMSUNG");
            Iron i3 = new Iron(100, "ATLANT");
            Frige f1 = new Frige(250,"BOSH");
            Frige f2 = new Frige(500,"INDEZIT");

            List<ElectricalAppliances> list = new List<ElectricalAppliances>();   // List of Apps
            list.Add(vc1);
            list.Add(vc2);
            list.Add(vc3);
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            list.Add(f1);
            list.Add(f2);

            Console.WriteLine("Electrical Appliances located at home:\n");
            PrintList(list); // Print of default list

            vc2.TurnOn();  // Turn on the apps
            i2.TurnOn();
            f2.TurnOn();

            list.Sort();  // Sort list by power

            Console.WriteLine("\nElectrical Appliances located at home and sorted by POWER:\n");
            PrintList(list);

            Console.WriteLine("\nTotal power consumed by turned ON Electrical Appliances = {0}", GetTotalPower(SortByStatus(list, "is turned ON")));

            Console.WriteLine("\nSearch apps by power!\nInsert lower border of power:");
            lowBord = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nInsert higher border of power:");
            highBord = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Appleances found by your request of power:");
            PrintList(FindByPower(list,lowBord,highBord));

            Console.WriteLine("\nPress any key in order to exit...");
            Console.ReadKey(true);

        }

        public static void PrintList(List<ElectricalAppliances> list) {

            foreach (ElectricalAppliances EA in list) 
            {
                Console.WriteLine("Type: {0}, Brand: {1}, Status: {2}, Power = {3}", EA.GetTypeOf(), EA.GetName(), EA.GetStatus(),EA.GetPower());
            }
        }

        public static List<ElectricalAppliances> SortByStatus(List<ElectricalAppliances> list,string condition) 
        {
            List<ElectricalAppliances> SortedList = new List<ElectricalAppliances>();
            foreach (ElectricalAppliances EA in list)
            {
                if(EA.GetStatus() == condition){
                    SortedList.Add(EA);
                }
            }
                return SortedList;
            }

        public static int GetTotalPower(List<ElectricalAppliances> list)
        {
            int totalPower = 0;

            foreach(ElectricalAppliances EA in list)
            {
                totalPower += EA.GetPower();
            }

            return totalPower;
        }

        public static List<ElectricalAppliances> FindByPower(List<ElectricalAppliances> list, int minCond, int maxCond) 
        {    
            List<ElectricalAppliances> SortedList = new List<ElectricalAppliances>();
            foreach (ElectricalAppliances EA in list)
            {
                if(EA.GetPower() >= minCond & EA.GetPower() <= maxCond){
                    SortedList.Add(EA);
                }
            }
                return SortedList;
            }

    }
}
