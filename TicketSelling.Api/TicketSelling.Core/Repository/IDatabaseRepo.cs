using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Repository
{
    public interface IDatabaseRepo
    {

        #region Concert
        bool AddConcert(Concert concert);
        bool UpdateConcert(int Id, Concert concert);
        bool DeleteConcert(int Id);
        Concert GetConcert(int Id);
        List<Concert> GetConcerts();
        #endregion

        bool AddCustomer(Customer customer);
        bool UpdateAddress(int Id, string Address);
        bool DeleteCustomer(int Id);
        Customer GetCustomer(int Id);
        List<Customer> GetCustomers();

        
        bool AddTicket(Ticket ticket);
        bool UpdateTicket(int Id, int Price);
        bool DeleteTicket(int Id);
        List<Ticket> GetTickets();
        Ticket GetTicket(int Id);


        bool BuyTicket(int Customer_Id, int Ticket_Id);
        Concert GetBoughtTicketsByConcert(int Concert_Id);
        List<Reservation> GetReservations();
        Customer GetBoughtTicketsByCustomers(int Customer_Id);
        User GetUser(string username, string password);





    }
}
