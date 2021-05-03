using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class IndexIsNotCorrectFormattedException : Exception
    {
        public IndexIsNotCorrectFormattedException()
        {
        }

        public IndexIsNotCorrectFormattedException(string message)
            : base(message)
        {
        }

        public IndexIsNotCorrectFormattedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

