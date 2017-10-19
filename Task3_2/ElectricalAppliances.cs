using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    [Serializable]
    abstract class ElectricalAppliances : ICloneable ,IComparable<ElectricalAppliances> // Delete inheritance of interface IComparable in order to check InvalidOperationException

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
            try
            {
                if(_status == "is turned ON")
                {
                    throw new TwiceOperationException("Already turned ON");                      //2nd custom Exception
                }
                _status = "is turned ON";
            }

            catch (TwiceOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        public void TurnOFF()
        {

            try
            {
                if (_status == "is turned OFF")
                {
                    throw new TwiceOperationException("Already turned OFF");                      //2nd custom Exception
                }
                _status = "is turned OFF";
            }

            catch (TwiceOperationException e)
            {
                Console.WriteLine(e);
            }
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

        public object Clone()
        {
            throw new NotImplementedException("You have forgotten implement the interface"); //5th system Exception
        }
    }
    }

