using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;

namespace TicketSelling.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDatabaseRepo repo;
        public CustomerService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }
        public bool AddCustomer(Customer customer)
        {
            if (customer == null) return false;

            return repo.AddCustomer(customer);
        }

        public bool UpdateAddress(int Id, string Address)
        {
            Customer foundCustomer = repo.GetCustomer(Id);
            if (foundCustomer == null)
                throw new ApplicationException("Customer does not exist!");

            return repo.UpdateAddress(Id, Address);
        }
       public bool DeleteCustomer(int Id)
        {
            Customer customer = repo.GetCustomer(Id);

            if (customer == null) return true;
            return repo.DeleteCustomer(Id);
        }
       public Customer GetCustomer(int Id)
        {
            return repo.GetCustomer(Id);
        }
        public List<Customer> GetCustomers()
        {
            return repo.GetCustomers();
        }


       public bool BuyTicket(int Customer_Id, int Ticket_Id)
        {
            //var customer = repo.GetCustomer(Id);

            //if (customer == null)
            //    throw new System.ApplicationException("Customer does not exist!");

            //var ticket = repo.GetTicket(Id);

            //if (ticket == null)
            //    throw new System.ApplicationException("Ticket does not exist!");

            return repo.BuyTicket(Customer_Id, Ticket_Id);

        }

        public Customer GetBoughtTicketsByCustomers1(int Customer_Id)
        {
            return repo.GetBoughtTicketsByCustomers(Customer_Id);
        }
    }


}
