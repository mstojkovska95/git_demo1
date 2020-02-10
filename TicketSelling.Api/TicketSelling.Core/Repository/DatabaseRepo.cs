using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using log4net;
using System.Data.SqlClient;
using TicketSelling.Core.DbHelper;
using Dapper;
using System.Data;

namespace TicketSelling.Core.Repository
{
    public class DatabaseRepo : IDatabaseRepo
    {
        ILog logger;

        public DatabaseRepo(ILog logger)
        {
            this.logger = logger;
        }

        #region Concerts

        public bool AddConcert(Concert concert)
        {
            try
            {
                using (SqlConnection coon = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Name", concert.Name);
                    parameters.Add("@Description", concert.Description);
                    parameters.Add("@Artist_Name", concert.Artist_Name);
                    parameters.Add("@Date", concert.Date);
                    parameters.Add("@Venue", concert.Venue);
                    parameters.Add("@City", concert.City);
                    parameters.Add("@Country", concert.Country);

                    int result = coon.Execute("CreateEvent", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while adding the concert!" + ex.Message, ex);
                return false;
            }
        }

        public bool DeleteConcert(int Id)
        {
            logger.Info("Deleting concert" + Id);
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    int result = conn.Execute("DeleteEvent",parameters,commandType: CommandType.StoredProcedure);
                    return result > 0;

                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while deleting the concert!" + ex.Message, ex);
                return false;
            }
        }

        public Concert GetConcert(int Id)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    Concert result = conn.Query<Concert>("SelectEvent", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error while getting the concert" + ex.Message, ex);
                return null;

            }
        }

        public List<Concert> GetConcerts()
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                    List<Concert> result = conn.Query<Concert>("SelectConcerts", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happing while loading the concerts" + ex.Message, ex);
                return null;
            }
        }

        public bool UpdateConcert(int Id, Concert concert)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    parameters.Add("@Name", concert.Name);
                    parameters.Add("@Description", concert.Description);
                    parameters.Add("@Artist_Name", concert.Artist_Name);
                    parameters.Add("@Date", concert.Date);
                    parameters.Add("@Venue", concert.Venue);
                    parameters.Add("@City", concert.City);
                    parameters.Add("@Country", concert.Country);

                    int result = conn.Execute("UpdateEvent", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while updating the concert" + ex.Message, ex);
                return false;
            }
        }
        #endregion

        #region Customers
        public bool AddCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn= DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@First_Name", customer.First_Name);
                    parameters.Add("@Last_Name", customer.Last_Name);
                    parameters.Add("@Age", customer.Age);
                    parameters.Add("@Email", customer.Email);
                    parameters.Add("@Address", customer.Address);
                    parameters.Add("@City", customer.City);
                    parameters.Add("@Country", customer.Country);

                    int result = conn.Execute("CreateCustomer", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error happened while adding the customer."+ ex.Message ,ex);
                return false;
                
            }
        }
       public bool UpdateAddress(int Id, string Address)
        {
            try
            {
                using(SqlConnection conn= DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    parameters.Add("@Address", Address);

                    int result = conn.Execute("UpdateAddress", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while updating the address." + ex.Message, ex);
                return false;
            }

        }
        public bool DeleteCustomer(int Id)
        {
            try
            {
                using(SqlConnection conn= DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    int result = conn.Execute("DeleteCustomer", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("An error happened while deleting the customer." + ex.Message, ex);
                return false;
            }
        }
        public Customer GetCustomer(int Id)
        {
            try
            {
                using(SqlConnection conn= DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    Customer result = conn.Query<Customer>("GetCustomer", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error("An error happened while loading the customer." + ex.Message, ex);
                return null;
                
            }
        }
        public List<Customer> GetCustomers()
        {
            try
            {
                using(SqlConnection conn= DbAccess.GetConnection())
                {
                    List<Customer> result = conn.Query<Customer>("SelectCustomers", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error("An error happened while loading customers." + ex.Message, ex);
                return null;
                
            }
        }

        #endregion

        #region Tickets

        public bool AddTicket(Ticket ticket)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Concert_Id", ticket.Concert_Id);
                    parameters.Add("@Price", ticket.Price);

                    int result = conn.Execute("AddTicket", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;


                }
            }
            catch (Exception ex)
            {

                logger.Error("An error happened while adding the ticket." + ex.Message, ex);
                return false;
            }
        }
       public bool UpdateTicket(int Id, int Price)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    parameters.Add("@Price", Price);

                    int result = conn.Execute("UpdateTicket", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while updating the student!" + ex.Message, ex);
                return false;
            }
        }
       public bool DeleteTicket(int Id)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    int result = conn.Execute("DeleteTicket", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("An error happened while deleting the ticket." + ex.Message, ex);
                return false;
            }
        }
        public List<Ticket> GetTickets()
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    List<Ticket> result = conn.Query<Ticket>("GetTickets", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                logger.Error("An error happened while loading the tickets." + ex.Message, ex);
                return null;
            }
        }

        public Ticket GetTicket(int Id)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    Ticket result = conn.Query<Ticket>("GetTicketId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while loading the ticket!" + ex.Message, ex);
                return null;
            }
        }


        #endregion


      public bool BuyTicket(int Customer_Id, int Ticket_Id)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Customer_Id", Customer_Id);
                    parameters.Add("@Ticket_Id", Ticket_Id);

                    int result = conn.Execute("BuyTicket", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while buying ticket." + ex.Message, ex);
                return false;
            }
        }



       public Concert GetBoughtTicketsByConcert(int Concert_Id)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Concert_Id", Concert_Id);

                    Concert result = conn.Query<Concert>("GetBoughtTicketsByConcert", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;

                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while loading." + ex.Message, ex);
                return null;
            }
        }


       public List<Reservation> GetReservations()
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                   List<Reservation> result = conn.Query<Reservation>("GetReservations", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                logger.Error("Failed to load reservations" + ex.Message, ex);
                return null;
            }
        }


        public Customer GetBoughtTicketsByCustomers(int Customer_Id)
        {
            try
            {
                using(SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Customer_Id", Customer_Id);

                    Customer result = conn.Query<Customer>("GetBoughtTicketsByCustomers", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;

                }
            }
            catch (Exception ex)
            {

                logger.Error("Error happened while bought tickets by customers!" + ex.Message, ex);
                return null;
            }
        }

        //User loggin
        public User GetUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@username", username);
                    parameter.Add("@password", password);

                    User result = conn.Query<User>("spUserLogin", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the product! " + e.Message, e);
                return null;
            }
        }

    }
}
