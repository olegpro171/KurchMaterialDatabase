using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class DuplicateRelationException : Exception
    {
        public DuplicateRelationException()
        {
        }

        public DuplicateRelationException(string message)
            : base(message)
        {
        }

        public DuplicateRelationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
