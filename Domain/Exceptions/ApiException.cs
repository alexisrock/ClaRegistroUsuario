using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ApiException : Exception
    {
        public int StatusCode { get; }
        public string Message { get; }



        public ApiException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
