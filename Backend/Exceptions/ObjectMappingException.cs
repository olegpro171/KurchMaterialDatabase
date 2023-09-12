using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class ObjectMappingException : Exception
    {
        public ObjectMappingException() { }

        public ObjectMappingException(string message) : base(message) { }

        public ObjectMappingException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
