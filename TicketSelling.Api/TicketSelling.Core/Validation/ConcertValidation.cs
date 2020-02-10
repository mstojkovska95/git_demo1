using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TicketSelling.Core.Models;

namespace TicketSelling.Core.Validation
{
    public class ConcertValidation:AbstractValidator<Concert>
    {

        public ConcertValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Artist_Name).NotEmpty().WithMessage("Artist name required!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date required!");
            RuleFor(x => x.City).NotEmpty().WithMessage("City required!");
        }
    }
}
