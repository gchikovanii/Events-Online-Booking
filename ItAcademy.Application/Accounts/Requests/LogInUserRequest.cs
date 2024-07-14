using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.Application.Accounts.Requests
{
    public class LogInUserRequest
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
