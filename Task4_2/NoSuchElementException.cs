using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    public class NoSuchElementException: ApplicationException //Processing the exception in case of working with absent element
    {
        public NoSuchElementException()
        {

        }

        public NoSuchElementException(string message): base (message)
        {
        }

        public NoSuchElementException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
