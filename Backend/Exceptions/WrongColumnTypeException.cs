using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class WrongColumnTypeException : Exception
    {
        public WrongColumnTypeException()
        {
        }

        public WrongColumnTypeException(string message)
            : base(message)
        {
        }

        public WrongColumnTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
