﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    [Serializable]
    class Frige:ElectricalAppliances
    {
        int _temperature;

        public Frige():this(0, "unknown")
        { 
        }

        public Frige(int power, string name) : base(power, name) 
        {
            _temperature = 20;
            _type = "Refrigerator";
        }

       public void GetFreeze()
       {
           _temperature = -20;
           _status = "is turned ON";
       }

    }
}
