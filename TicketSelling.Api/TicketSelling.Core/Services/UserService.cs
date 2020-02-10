using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;

namespace TicketSelling.Core.Services
{
    public class UserService : IUserService
    {
        private IDatabaseRepo repo;

        public UserService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

        public User ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

            return repo.GetUser(username, password);
        }
    }
}
