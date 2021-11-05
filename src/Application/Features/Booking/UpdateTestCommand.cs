using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTO;
using MediatR;

namespace Application.Features.Booking
{
    public class UpdateTestCommand : IRequest<BookingResponseII>
    {
        public string Email { get; set; }
        public string TestResult { get; set; }
    }
}