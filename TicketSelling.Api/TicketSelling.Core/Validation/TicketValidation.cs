using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Validation
{
   public class TicketValidation:AbstractValidator<Ticket>
    {
        public TicketValidation()
        {
            RuleFor(x => x.Concert_Id).NotEmpty().WithMessage("Ticket must have concert Id!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ticket must have a price!");
        }
    }
}
