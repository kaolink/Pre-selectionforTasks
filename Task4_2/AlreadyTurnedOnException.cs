using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    class TwiceOperationException : ApplicationException             //  Processing the exception in case of double turning ON or OFF the app
    {
        public TwiceOperationException()
        {

        }

        public TwiceOperationException(string message) : base("You tried to proceed the same procedure twice!")
        {
        }

        public TwiceOperationException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}

