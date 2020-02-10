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
    public class ConcertsController : ApiController

    {
        private readonly IConcertService service;

        public ConcertsController(IConcertService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        // GET: api/Concerts
        public IEnumerable<Concert> Get()
        {
            return service.GetConcerts();
        }

        [AllowAnonymous]
        // GET: api/Concerts/5
        public IHttpActionResult Get(int Id)
        {
            var concert = this.service.GetConcert(Id);

            if(concert==null)
            {
                return NotFound();
            }
            return base.Ok(concert);
        }


        [Authorize(Roles = "admin")]
        // POST: api/Concerts
        public HttpResponseMessage Post(Concert concert)
        {
            ConcertValidation validator = new ConcertValidation();
            var concertService = validator.Validate(concert);

            if (!concertService.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddConcert(concert))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        [Authorize(Roles = "admin")]
        // PUT: api/Concerts/5
        public IHttpActionResult Put(int Id, Concert concert)
        {
            try
            {
                if (service.UpdateConcert(Id,concert))
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
        // DELETE: api/Concerts/5
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (service.DeleteConcert(Id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {

                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
                
            }
        }


        [Authorize(Roles = "admin")]
        [Route("api/concerts/{Concert_Id}/getBoughtTicketsByConcert")]
        [HttpGet]
        public IHttpActionResult GetBoughtTicketsByConcert(int Concert_Id)
        {
            var concert = service.GetBoughtTicketsByConcert(Concert_Id);

            if (concert == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(concert);
            }
        }
    }
}
