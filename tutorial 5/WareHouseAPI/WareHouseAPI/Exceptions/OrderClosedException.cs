using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseAPI.Exceptions
{
    public class OrderClosedException : Exception
    {
        public OrderClosedException()
        {
        }

        public OrderClosedException(string message)
            : base(message)
        {
        }

        public OrderClosedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
