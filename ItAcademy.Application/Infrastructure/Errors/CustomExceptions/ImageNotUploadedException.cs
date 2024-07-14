using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class ImageNotUploadedException : Exception
    {
        public ImageNotUploadedException(string message) : base(message)
        {
        }
    }
}
