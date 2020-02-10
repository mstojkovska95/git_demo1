using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;

namespace TicketSelling.Core.Services
{
    public class ReservationService:IReservationService
    {
        private readonly IDatabaseRepo repo;
        public ReservationService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }
       public List<Reservation> GetReservations()
        {
            return repo.GetReservations();
        }
    }
}
