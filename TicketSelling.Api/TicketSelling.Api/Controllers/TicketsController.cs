using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSelling.Core.Models;
using TicketSelling.Core.Services;
using TicketSelling.Core.Validation;

namespace TicketSelling.Api.Controllers
{
    [Authorize]
    public class TicketsController : ApiController
    {

        private readonly ITicketService service;
        public TicketsController(ITicketService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "user, admin")]
        // GET: api/Tickets
        public IEnumerable<Ticket> Get()
        {
            return service.GetTickets();
        }

        [Authorize(Roles = "user, admin")]
        // GET: api/Tickets/5
        public IHttpActionResult Get(int Id)
        {
            var ticket = this.service.GetTicket(Id);

            if (ticket == null)
            {
                return NotFound();
            }
            return base.Ok(ticket);
        }


        [Authorize(Roles = "admin")]
        // POST: api/Tickets
        public HttpResponseMessage Post(Ticket ticket)
        {
            TicketValidation validator = new TicketValidation();
            var result = validator.Validate(ticket);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddTicket(ticket))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        [Authorize(Roles = "admin")]
        // PUT: api/Tickets/5
        public IHttpActionResult Put(int Id, int Price)
        {
            try
            {
                if (service.UpdateTicket(Id, Price))
                {
                    return Ok();
                }
                return InternalServerError();

            }
            catch (ApplicationException)
            {

                return NotFound();
            }
        }


        [Authorize(Roles = "admin")]
        // DELETE: api/Tickets/5
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (service.DeleteTicket(Id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {

                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }


       

        }
        

    }

