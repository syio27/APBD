using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.exceptions
{
    class DupclicateStudentException : Exception
    {
        public DupclicateStudentException()
        {
        }

        public DupclicateStudentException(string message)
            : base(message)
        {
        }

        public DupclicateStudentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
