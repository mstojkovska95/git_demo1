using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;

namespace TicketSelling.Core.Services
{
    public class TicketService:ITicketService
    {
        private readonly IDatabaseRepo repo;

        public TicketService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

       public bool AddTicket(Ticket ticket)
        {
            if (ticket == null) return false;

            return repo.AddTicket(ticket);
        }
        
       public bool UpdateTicket(int Id, int Price)
        {
            var foundTicket = repo.GetTicket(Id);

            if (foundTicket == null)
                throw new ApplicationException("Ticket does not exist!");

            return repo.UpdateTicket(Id, Price);
        }
       public bool DeleteTicket(int Id)
        {
            //var foundTicket = repo.GetTicket(Id);
            return repo.DeleteTicket(Id);
        }
       public List<Ticket> GetTickets()
        {
            return repo.GetTickets();
        }

        public Ticket GetTicket(int Id)
        {
            return repo.GetTicket(Id);
        }

   

     



    }
}
