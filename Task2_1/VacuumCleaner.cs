using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    class VacuumCleaner : ElectricalAppliances
    {
        int _rev;

        public VacuumCleaner()
        {

        }

        public VacuumCleaner(int power, string name):base(power,name)
        {
            _rev = 0;
            _type = "Vacuum Cleaner";

        }

        public void IncreaceRev(int deltaRev)
        {
            _rev += deltaRev;
        }

        public void ReduceRev(int deltaRev)
        {
            _rev -= deltaRev;
        }

        public void GetRev()
        {
            Console.WriteLine(_rev);
        }
    }
}
