using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Exceptions
{
    internal class InvalidConnectionDataException : Exception
    {
        public InvalidConnectionDataException()
        {
        }

        public InvalidConnectionDataException(string message)
            : base(message)
        {
        }

        public InvalidConnectionDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
