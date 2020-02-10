using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSelling.Core.Models;
using TicketSelling.Core.Repository;
using TicketSelling.Core.Services;

namespace TicketSelling.Api.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReservationsController : ApiController
    {

        private readonly IReservationService service;

        public ReservationsController(IReservationService service)
        {
            this.service = service;
        }

       
        // GET: api/Reservations
        public IEnumerable<Reservation> Get()
        {
            return service.GetReservations();
        }

       
    }
}
