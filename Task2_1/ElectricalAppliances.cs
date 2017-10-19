using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    abstract class ElectricalAppliances : IComparable<ElectricalAppliances>

    {
        private int _power;
        private string _name;
        protected string _status;
        protected string _type; 

        public ElectricalAppliances()
            : this(0, "unknown")
        {

        }

        public ElectricalAppliances(int power, string name)
        {
            _power = power;
            _name = name;
            _status = "is turned OFF";
        }

        public void TurnOn()
        {
            _status = "is turned ON";
        }

        public void TurnOFF()
        {
            _status = "is turned OFF";
        }

        public string GetStatus()
        {

            return _status;

        }

        public string GetName()
        {
            return _name;
        }

        public string GetTypeOf()
        {
            return _type;
        }

        public int GetPower()
        {
            return _power;
        }

        public int CompareTo(ElectricalAppliances other)
        {
            int result;

            if (_power > other._power)
            {
                result = 1;
            }
            else if (_power < other._power)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
