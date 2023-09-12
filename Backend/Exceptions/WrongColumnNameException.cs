using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class WrongColumnNameException : Exception
    {
        public WrongColumnNameException()
        {
        }

        public WrongColumnNameException(string message)
            : base(message)
        {
        }

        public WrongColumnNameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
