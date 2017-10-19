using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    class Iron : ElectricalAppliances
    {
        int _temperature;

        public Iron()
        {

        }

        public Iron(int power, string name):base(power,name)
        {
            _temperature = 20;
            _type = "Iron";
        }
        public void GetHeat(int deltaTemp)
        {

            _status = "is turned ON";
            _temperature += deltaTemp;
        }

        public void TurnOff()
        {
            _status = "is turned OFF";
            _temperature = 20;
        }


    }
}
