using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseAPI.Exceptions
{
    public class TransactionErrorException : Exception
    {
        public TransactionErrorException()
        {
        }

        public TransactionErrorException(string message)
            : base(message)
        {
        }

        public TransactionErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
