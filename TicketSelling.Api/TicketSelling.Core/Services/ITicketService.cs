using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Services
{
   public interface ITicketService
    {
        bool AddTicket(Ticket ticket);
        bool UpdateTicket(int Id, int Price);
        bool DeleteTicket(int Id);
        List<Ticket> GetTickets();
        Ticket GetTicket(int Id);
        
        

    }
}
