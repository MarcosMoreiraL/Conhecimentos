using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Library.Exceptions
{
    public class FinAppValidationException : Exception
    {
        public FinAppValidationException()
        {
        }

        public FinAppValidationException(string? message) : base(message)
        {
        }

        public FinAppValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
