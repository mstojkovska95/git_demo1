using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace TicketSelling.Core.DbHelper
{
    class DbAccess
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSales"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
