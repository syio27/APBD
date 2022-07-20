using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class StringIsEmptyException : Exception
    {
        public StringIsEmptyException()
        {
        }

        public StringIsEmptyException(string message)
            : base(message)
        {
        }

        public StringIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

