using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    class NullElementException : ApplicationException       // Processing the exception in case of working with null element
    {
        public NullElementException()
        {

        }

        public NullElementException(string message): base ("Error due to trying to work with null element")     
        {
        }

        public NullElementException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
