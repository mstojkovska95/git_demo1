using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Services
{
    public interface ICustomerService
    {
        bool AddCustomer(Customer customer);
        bool UpdateAddress(int Id, string Address);
        bool DeleteCustomer(int Id);
        Customer GetCustomer(int Id);
        List<Customer> GetCustomers();
        bool BuyTicket(int Customer_Id, int Ticket_Id);

        Customer GetBoughtTicketsByCustomers1(int Customer_Id);
    }
}
