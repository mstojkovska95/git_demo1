using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Models
{
    public class Customer
    {
        //[JsonProperty("customer_Id")]
        public int Customer_Id { get; set; }

        //[JsonProperty("first_Name")]
        public string First_Name { get; set; }

       // [JsonProperty("last_Name")]
        public string Last_Name { get; set; }

       // [JsonProperty("age")]
        public int Age { get; set; }

       // [JsonProperty("email")]
        public string Email { get; set; }

        //[JsonProperty("address")]
        public string Address { get; set; }

       // [JsonProperty("city")]
        public string City { get; set; }

        //[JsonProperty("country")]
        public string Country { get; set; }

        public int Tickets_Bought { get; set; }
    }
}
