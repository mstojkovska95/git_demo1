using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Models
{
   public class Reservation
    {

       // [JsonProperty("id")]
        public int Id { get; set; }

       // [JsonProperty("customer_Id")]
        public int Customer_Id { get; set; }

       // [JsonProperty("ticket_Id")]
        public int Ticket_Id { get; set; }

       // [JsonProperty("reservation_Time")]
        public DateTime Reservation_Time { get; set; }
    }
}
