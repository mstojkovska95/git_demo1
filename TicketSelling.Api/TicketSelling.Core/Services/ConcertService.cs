using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;

namespace TicketSelling.Core.Services
{
    public class ConcertService : IConcertService
    {
        private readonly IDatabaseRepo repo;

        public ConcertService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

       public bool AddConcert(Concert concert)
        {
            if (concert == null) return false;

            return repo.AddConcert(concert);
        }
       public bool UpdateConcert(int Id, Concert concert)
        {
            var foundConcert = repo.GetConcert(Id);

            if (foundConcert == null)
                throw new ApplicationException("Concert does not exist!");

            return repo.UpdateConcert(Id, concert);

        }
       public bool DeleteConcert(int Id)
        {
            Concert foundConcert = repo.GetConcert(Id);

            if (foundConcert == null) return true;

            return repo.DeleteConcert(Id);
        }
        public Concert GetConcert(int Id)
        {
            return repo.GetConcert(Id);
        }
        public List<Concert> GetConcerts()
        {
            return repo.GetConcerts();
        }

        public Concert GetBoughtTicketsByConcert(int Concert_Id)
        {
            return repo.GetBoughtTicketsByConcert(Concert_Id);
        }
    }
}
