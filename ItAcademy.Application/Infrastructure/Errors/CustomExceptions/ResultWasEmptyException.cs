using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class ResultWasEmptyException : Exception
    {
        public ResultWasEmptyException(string message): base(message)
        {
        }
    }
}
