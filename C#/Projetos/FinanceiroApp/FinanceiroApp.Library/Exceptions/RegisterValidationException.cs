using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Library.Exceptions
{
    public class RegisterValidationException : Exception
    {
        public RegisterValidationException()
        {
        }

        public RegisterValidationException(string? message) : base(message)
        {
        }

        public RegisterValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
