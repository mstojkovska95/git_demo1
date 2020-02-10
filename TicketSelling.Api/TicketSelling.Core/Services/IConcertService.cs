using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Services
{
    public interface IConcertService
    {
        bool AddConcert(Concert concert);
        bool UpdateConcert(int Id, Concert concert);
        bool DeleteConcert(int Id);
        Concert GetConcert(int Id);
        List<Concert> GetConcerts();
        Concert GetBoughtTicketsByConcert(int Concert_Id);
    }
}
