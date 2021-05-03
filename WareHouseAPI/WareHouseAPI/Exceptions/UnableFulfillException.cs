using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseAPI.Exceptions
{
    public class UnableFulfillException : Exception
    {
        public UnableFulfillException()
        {
        }

        public UnableFulfillException(string message)
            : base(message)
        {
        }

        public UnableFulfillException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
