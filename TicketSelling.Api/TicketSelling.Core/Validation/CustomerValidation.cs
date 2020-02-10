using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Validation
{
    public class CustomerValidation:AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.First_Name).NotEmpty().WithMessage("Customer first name is required!");
            RuleFor(x => x.Last_Name).NotEmpty().WithMessage("Customer last name is required!");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Age must be 18 or greater");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Address is not correct.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required!");

        }
    }
}
