using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Models
{
    public class Ticket
    {

        //[JsonProperty("ticket_Id")]
        public int Ticket_Id { get; set; }

        //[JsonProperty("concert_Id")]
        public int Concert_Id { get; set; }

        //[JsonProperty("price")]
        public int Price { get; set; }

       
    }
}
