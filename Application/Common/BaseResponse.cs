using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    [ExcludeFromCodeCoverage]
    public class BaseResponse
    {
        public string message { get; set; } = string.Empty;

    }
}
