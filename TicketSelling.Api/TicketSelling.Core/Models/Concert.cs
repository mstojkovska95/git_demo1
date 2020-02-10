
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Models
{
    public class Concert
    {
       // [JsonProperty("concert_Id")]
        public int Concert_Id { get; set; }

       // [JsonProperty("name")]
        public string Name { get; set; }

       // [JsonProperty("description")]
        public string Description { get; set; }

       // [JsonProperty("artist_Name")]
        public string Artist_Name { get; set; }

       // [JsonProperty("date")]
        public DateTime Date { get; set; }

       // [JsonProperty("venue")]
        public string Venue { get; set; }

        //[JsonProperty("city")]
        public string City { get; set; }

        //[JsonProperty("country")]
        public string Country { get; set; }

        public int TicketsBought { get; set; }

    }
}
