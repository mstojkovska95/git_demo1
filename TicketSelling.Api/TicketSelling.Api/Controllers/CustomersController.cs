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
    public class CustomersController : ApiController
    {
        private readonly ICustomerService service;
        public CustomersController(ICustomerService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "admin")]
        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            return service.GetCustomers();
        }


        [Authorize(Roles = "admin")]
        //// GET: api/Customers/5
        public IHttpActionResult Get(int Id)
        {
            var customer = this.service.GetCustomer(Id);

            if (customer == null)
            {
                return NotFound();
            }
            return base.Ok(customer);

        }


        [AllowAnonymous]
        // POST: api/Customers
        public HttpResponseMessage Post(Customer customer)
        {
            CustomerValidation validator = new CustomerValidation();

            var customerService = validator.Validate(customer);

            if (!customerService.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);


            if (service.AddCustomer(customer))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        [Authorize(Roles = "user")]
        // PUT: api/Customers/5
        public IHttpActionResult Put(int Id, string Address)
        {

            try
            {
                if (service.UpdateAddress(Id, Address))
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
        //// DELETE: api/Customers/5
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (service.DeleteCustomer(Id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {

                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }


        [Authorize(Roles = "user")]
        [Route("api/customers/{Customer_Id}/buyTicket/{Ticket_Id}")]
        [HttpPost]
        public HttpResponseMessage BuyTicket(int Customer_Id, int Ticket_Id)
        {
            try
            {
                var buy = service.BuyTicket(Customer_Id, Ticket_Id);

                  if (buy)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to buy a ticket!");

            }
            catch (ApplicationException ex)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }


        [Authorize(Roles = "admin")]
        [Route("api/customers/{Customer_Id}/getBoughtTicketsByCustomers")]
        [HttpGet]
        public IHttpActionResult GetBoughtTicketsByCustomers(int Customer_Id)
        {
            var customer = service.GetBoughtTicketsByCustomers1(Customer_Id);

            if (customer == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(customer);
            }
        }

        }
}
