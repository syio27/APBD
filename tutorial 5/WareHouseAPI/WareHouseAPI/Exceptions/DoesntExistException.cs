using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseAPI.Exceptions
{
    public class DoesntExistException : Exception
    {
        public DoesntExistException()
        {
        }

        public DoesntExistException(string message)
            : base(message)
        {
        }

        public DoesntExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
