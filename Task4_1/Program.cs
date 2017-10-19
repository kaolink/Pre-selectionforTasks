using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int lowBord = 0;
            int highBord = 0;
            string path = @"D:\myData.txt";
            string pathSer = @"D:\mySerData.txt";
            string pathXmL = @"D:\myData.xml";

            VacuumCleaner vc1 = new VacuumCleaner(100, "PHILIPS");    // Apps initialization
            VacuumCleaner vc2 = new VacuumCleaner(150, "LG");
            VacuumCleaner vc3 = new VacuumCleaner(80, "HORIZONT");
            Iron i1 = new Iron(50, "VITEC");
            Iron i2 = new Iron(95, "SAMSUNG");
            Iron i3 = new Iron(100, "ATLANT");
            Frige f1 = new Frige(250, "BOSH");
            Frige f2 = new Frige(500, "INDEZIT");
            // Frige f3 = null; //delete the comment in order to check NullReferenceException
            Frige f4 = new Frige();
            WorkWithFile wf = new WorkWithFile();
            WorkWithFileSerialize wfs = new WorkWithFileSerialize();
            DataInXmL xmlData = new DataInXmL();


            List<ElectricalAppliances> list = new List<ElectricalAppliances>();   // List of Apps
            list.Add(vc1);
            list.Add(vc2);
            list.Add(vc3);
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            list.Add(f1);
            list.Add(f2);
            // list.Add(f3); //delete the comment in order to check NullReferenceException
            list.Add(f4);
            RemoveFromList(list, f4);  


            try
            {
                //RemoveFromList(list,f4);  //delete the comment in order to check NoSuchElementException
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine("You're trying to remove unexist item from the list, find details here:{0}", e);
            }


            Console.WriteLine("Electrical Appliances located at home:\n");
            PrintList(list); // Print of default list



            try
            {
                //vc2.TurnOFF(); //delete the comment in order to check AlreadyTurnedOnException
                vc2.TurnOn();  // Turn on the apps
                i2.TurnOn();
                f2.TurnOn();
                //f2.TurnOn(); //delete the comment in order to check AlreadyTurnedOnException
            }

            catch (TwiceOperationException e)
            {
                Console.WriteLine("Can't proceed it twice, please find details here={0}",e);
            }


            try
            {
                list.Sort();  // Sort list by power

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Seems like you haven't implemented Icomprable interface, find details here:{0}", e);   //1st system Exception
            }



            Console.WriteLine("\nElectrical Appliances located at home and sorted by POWER:\n");
            PrintList(list);

            Console.WriteLine("\nTotal power consumed by turned ON Electrical Appliances = {0}", GetTotalPower(SortByStatus(list, "is turned ON")));

            Console.WriteLine("\nSearch apps by power!\nInsert lower border of power:");

            try
            {
                lowBord = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nInsert higher border of power:");

            
                highBord = Int32.Parse(Console.ReadLine());
            }
            catch (OverflowException e)
            {
                Console.WriteLine("You've inserted too large value, find details here:{0}",e);  // 3rd system Exception
            }
            catch(FormatException e)
            {
                Console.WriteLine("You've inserted invalid value, find details here:{0}", e);  // 4th system Exception
            }
            Console.WriteLine("\nAppliances found by your request of power:");
            PrintList(FindByPower(list, lowBord, highBord));


            wf.Write(list, path);  //Write data from the list to the file by using FileStream
            Console.WriteLine("\nData from the file:");
            wf.Read(path); // Write data from the list to the file by using FileStream

            wfs.Serialize(list,pathSer);                         // Serialize data from the list
            PrintList(wfs.Deserialize(pathSer));                 // Deserialize data from the list and print

            xmlData.SerializeXml(list,pathXmL);       //Load data to XML file by using serialization
            PrintList(xmlData.DeserializeXml(pathXmL));          //Load data from XML file by using deserialization and print the result

            Console.WriteLine("\nPress any key in order to exit...");
            Console.ReadKey(true);



        }

        public static void PrintList(List<ElectricalAppliances> list)
        {

            try
            {
                foreach (ElectricalAppliances EA in list)
                {
                    Console.WriteLine("Type: {0}, Brand: {1}, Status: {2}, Power = {3}", EA.GetTypeOf(), EA.GetName(), EA.GetStatus(), EA.GetPower());
                }
            }

            catch (NullReferenceException e)
            {
                Console.WriteLine("Can't get data from null object, find details here:{0}",e);   // 2nd system Exception
            }
        }

        public static List<ElectricalAppliances> SortByStatus(List<ElectricalAppliances> list, string condition) 
        {
            List<ElectricalAppliances> SortedList = new List<ElectricalAppliances>();

            try
            {
                ValidateList(list);       
            }

            catch (NullElementException e) 
            {
                Console.WriteLine("Some elements in collection is null, find details here:{0}",e);
            }

            foreach (ElectricalAppliances EA in list)
            {
                try
                {
                    if (EA.GetStatus() == condition)
                    {
                        SortedList.Add(EA);
                    }
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine("Can't get data from null object, find details here:{0}", e);
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
                try
                {
                    if (EA.GetPower() >= minCond & EA.GetPower() <= maxCond)
                    {
                        SortedList.Add(EA);
                    }
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine("Some elements in collection is null, find details here:{0}", e);
                }
            }
                return SortedList;
            }

        public static void ValidateList (List<ElectricalAppliances> list)           // Validation of the list in case of null element
        {
            foreach(ElectricalAppliances EA in list)
            {
                if (EA == null)
                {
                    throw new NullElementException("You're trying to proccess null element!");  // 1st custom Exception
                }
            }
        }

        public static void RemoveFromList(List<ElectricalAppliances> list,ElectricalAppliances item)
        {
            if (list.Contains(item) == true)
            {
                list.Remove(item);
            }
            else
            {
                throw new NoSuchElementException("No such element in collection");    // 3rd custom Exception
            }
        }
    }
}
