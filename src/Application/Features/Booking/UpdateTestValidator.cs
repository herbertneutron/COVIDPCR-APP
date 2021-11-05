using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Booking
{
    public class UpdateTestValidator : AbstractValidator<UpdateTestCommand>
    {
        public UpdateTestValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("*Required");
            RuleFor(x => x.TestResult)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("*Required");    
        }
    }
}