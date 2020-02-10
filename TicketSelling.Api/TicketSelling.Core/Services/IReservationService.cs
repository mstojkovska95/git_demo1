using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Services
{
   public interface IReservationService
    {
        List<Reservation> GetReservations();
    }
}
