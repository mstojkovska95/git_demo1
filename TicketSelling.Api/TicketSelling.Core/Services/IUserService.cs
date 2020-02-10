using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Services
{
    public interface IUserService
    {
        User ValidateLogin(string username, string password);
    }
}
